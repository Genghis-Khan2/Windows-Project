using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BL
{
    public partial class BL_IMP
    {      
        public List<Product> GetProductFriends(Product product,User user)
        {            
            List<Product> friends = new List<Product>();
            List<int[]> productsIdSets = GetProductsIdSets(user.Orders);
            List<int[]> productsIdSetsRec = GetFrequentItemSets(Configuration.GlobalProducts.Count,
            productsIdSets, 0.3, 2, GetLongestTransaction(productsIdSets));
            foreach (var ProductsIdSet in productsIdSetsRec)
            {
                if (Array.Exists(ProductsIdSet, (x) => x == product.Id))
                    for (int i = 0; i < ProductsIdSet.Length; i++)
                    {
                        //efi is a friend. he is a good boy.
                        Product efi = Product.GetProductFromId(ProductsIdSet[i]);
                        if (!friends.Contains(efi) && efi.Id != product.Id)
                            friends.Add(efi);
                    }
            }           
            return friends;
        }
        private static List<int[]> GetProductsIdSets(List<Order> orders)
        {
            List<int[]> productsIdSets = new List<int[]>();
            foreach (var order in orders)
            {
                int[] productsIdSet = new int[order.Products.Count];
                for (int i = 0; i < order.Products.Count; i++)
                {
                    productsIdSet[i] = order.Products[i].Id;
                }
            }
            return productsIdSets;
        }
        private static List<int[]> GetFrequentItemSets(int N, List<int[]> transactions, double minSupportPct,
          int minItemSetLength, int maxItemSetLength)
        {
            // create a List of frequent ItemSet objects that are in transactions
            // frequent means occurs in minSupportPct percent of transactions
            // N is total number of items
            // uses a variation of the Apriori algorithm

            int minSupportCount = (int)(transactions.Count * minSupportPct);

            Dictionary<int, bool> frequentDict = new Dictionary<int, bool>(); // key = int representation of an ItemSet, val = is in List of frequent ItemSet objects
            List<ItemSet> frequentList = new List<ItemSet>(); // item set objects that meet minimum count (in transactions) requirement 
            List<int> validItems = new List<int>(); // inidividual items/values at any given point in time to be used to construct new ItemSet (which may or may not meet threshhold count)

            // get counts of all individual items
            int[] counts = new int[N]; // index is the item/value, cell content is the count
            for (int i = 0; i < transactions.Count; ++i)
            {
                for (int j = 0; j < transactions[i].Length; ++j)
                {
                    int v = transactions[i][j];
                    ++counts[v];
                }
            }
            // for those items that meet support threshold, add to valid list, frequent list, frequent dict
            for (int i = 0; i < counts.Length; ++i)
            {
                if (counts[i] >= minSupportCount) // frequent item
                {
                    validItems.Add(i); // i is the item/value
                    int[] d = new int[1]; // the ItemSet ctor wants an array
                    d[0] = i;
                    ItemSet ci = new ItemSet(N, d, 1); // an ItemSet with size 1, ct 1
                    frequentList.Add(ci); // it's frequent
                    frequentDict.Add(ci.hashValue, true); // 
                } // else skip this item
            }

            bool done = false; // done if no new frequent item-sets found
            for (int k = 2; k <= maxItemSetLength && done == false; ++k) // construct all size  k = 2, 3, 4, . .  frequent item-sets
            {
                done = true; // assume no new item-sets will be created
                int numFreq = frequentList.Count; // List size modified so store first

                for (int i = 0; i < numFreq; ++i) // use existing frequent item-sets to create new freq item-sets with size+1
                {
                    if (frequentList[i].k != k - 1) continue; // only use those ItemSet objects with size 1 less than new ones being created

                    for (int j = 0; j < validItems.Count; ++j)
                    {
                        int[] newData = new int[k]; // data for a new item-set

                        for (int p = 0; p < k - 1; ++p)
                            newData[p] = frequentList[i].data[p]; // old data in

                        if (validItems[j] <= newData[k - 2]) continue; // because item-values are in order we can skip sometimes

                        newData[k - 1] = validItems[j]; // new item-value
                        ItemSet ci = new ItemSet(N, newData, -1); // ct to be determined

                        if (frequentDict.ContainsKey(ci.hashValue) == true) // this new ItemSet has already been added
                            continue;
                        int ct = CountTimesInTransactions(ci, transactions); // how many times is the new ItemSet in the transactuions?
                        if (ct >= minSupportCount) // we have a winner!
                        {
                            ci.ct = ct; // now we know the ct
                            frequentList.Add(ci);
                            frequentDict.Add(ci.hashValue, true);
                            done = false; // a new item-set was created, so we're not done
                        }
                    } // j
                } // i

                // update valid items -- quite subtle
                validItems.Clear();
                Dictionary<int, bool> validDict = new Dictionary<int, bool>(); // track new list of valid items
                for (int idx = 0; idx < frequentList.Count; ++idx)
                {
                    if (frequentList[idx].k != k) continue; // only looking at the just-created item-sets
                    for (int j = 0; j < frequentList[idx].data.Length; ++j)
                    {
                        int v = frequentList[idx].data[j]; // item
                        if (validDict.ContainsKey(v) == false)
                        {
                            //Console.WriteLine("adding " + v + " to valid items list");
                            validItems.Add(v);
                            validDict.Add(v, true);
                        }
                    }
                }
                validItems.Sort(); // keep valid item-values ordered so item-sets will always be ordered
            } // next k


            List<int[]> result1 = new List<int[]>();
            for (int i = 0; i < frequentList.Count; ++i)
            {
                if (frequentList[i].k >= minItemSetLength)
                    result1.Add(frequentList[i].data);
            }

            // transfer to return result, filtering by minItemSetCount
            List<ItemSet> result = new List<ItemSet>();
            for (int i = 0; i < frequentList.Count; ++i)
            {
                if (frequentList[i].k >= minItemSetLength)
                    result.Add(new ItemSet(frequentList[i].N, frequentList[i].data, frequentList[i].ct));
            }

            return result1;
        }
        static int CountTimesInTransactions(ItemSet itemSet, List<int[]> transactions)
        {
            // number of times itemSet occurs in transactions
            int ct = 0;
            for (int i = 0; i < transactions.Count; ++i)
            {
                if (itemSet.IsSubsetOf(transactions[i]) == true)
                    ++ct;
            }
            return ct;
        }
        private static int GetLongestTransaction(List<int[]> transactions)
        {
            int max = 0;
            foreach (var trans in transactions)
            {
                if (max < trans.Length)
                    max = trans.Length;
            }
            return max;
        }

        /** functions from the example for printing etc
         * 
        private static void PrintRawTransactions(string[][] rawTransactions)
        {
            Console.WriteLine("Raw transactions are:");
            Console.WriteLine("-----------------------------------------------");
            for (int i = 0; i < rawTransactions.Length; ++i)
            {
                Console.Write("[" + i + "] : ");
                for (int j = 0; j < rawTransactions[i].Length; ++j)
                    Console.Write(rawTransactions[i][j] + "   ");
                Console.WriteLine("");
            }
        }

        private static void PrintTranactions(List<int[]> transactions)
        {
            Console.WriteLine("\n\nEncoded transactions are:");
            Console.WriteLine("-----------------------------------------------");
            for (int i = 0; i < transactions.Count; ++i)
            {
                Console.Write("[" + i + "] : ");
                for (int j = 0; j < transactions[i].Length; ++j)
                    Console.Write(transactions[i][j].ToString() + " ");
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        private static List<int[]> GetTransactions(string[] rawItems, string[][] rawTransactions)
        {
            List<int[]> transactions = new List<int[]>();

            foreach (string[] rawTrans in rawTransactions)
            {
                int[] newTransaction = new int[rawTrans.Length];
                for (int i = 0; i < rawTrans.Length; i++)
                {
                    newTransaction[i] = GetIndex(rawItems, rawTrans[i]);
                }
                Array.Sort(newTransaction);
                transactions.Add(newTransaction);
            }
            return transactions;
        }

        private static int GetIndex(string[] itemsNames, string item)
        {
            for (int i = 0; i < itemsNames.Length; i++)
            {
                if (itemsNames[i].Trim() == item.Trim())
                    return i;
            }
            return -1;
        }
        **/
    }

    public class ItemSet
    {
        public int N; // data items are [0..N-1]
        public int k; // number of items
        public int[] data; // ex: [0 2 5]
        public int hashValue; // "0 2 5" -> 520 (for hashing)
        public int ct; // num times this occurs in transactions

        public ItemSet(int N, int[] items, int ct)
        {
            this.N = N;
            this.k = items.Length;
            this.data = new int[this.k];
            Array.Copy(items, this.data, items.Length);
            this.hashValue = ComputeHashValue(items);
            this.ct = ct;
        }
        public override string ToString()
        {
            string s = "{ ";
            for (int i = 0; i < data.Length; ++i)
                s += data[i] + " ";
            return s + "}" + "   ct = " + ct; ;
        }
        public bool IsSubsetOf(int[] trans)
        {
            // 'trans' is an ordered transaction like [0 1 4 5 8]
            int foundIdx = -1;
            for (int j = 0; j < this.data.Length; ++j)
            {
                foundIdx = IndexOf(trans, this.data[j], foundIdx + 1);
                if (foundIdx == -1) return false;
            }
            return true;
        }
        private static int ComputeHashValue(int[] data)
        {
            int value = 0;
            int multiplier = 1;
            for (int i = 0; i < data.Length; ++i) // actually working backward
            {
                value = value + (data[i] * multiplier);
                multiplier = multiplier * 10;
            }
            return value;
        }
        private static int IndexOf(int[] array, int item, int startIdx)
        {
            for (int i = startIdx; i < array.Length; ++i)
            {
                if (i > item) return -1; // i is past where the target could possibly be
                if (array[i] == item) return i;
            }
            return -1;
        }


    }
}
