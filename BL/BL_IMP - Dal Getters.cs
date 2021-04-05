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
        DAL_IMP IDAL = new DAL_IMP();

        //public static List<Order> GetOrders(User user)
        //{           
        //    return user.Orders;
        //}

        public Product CreateNewProduct(string name, double price,double weight,
        string description, Category cat, string image_path= null)
        {
            if (image_path==null|| image_path == null)
            {
                image_path= @"C:\Users\eitha\Documents\מכון לב\הנדסת מערכת חלונים\WindowsProject\Photos\NotExist.PNG";
            }
            Product product= new Product() { Name=name,Price=price,Weight=weight,
                Description=description,Cat=cat,Image_path=image_path,
                Available = true
            };
            product.Id = AddId(product);
            product.Qr_code_path = CreateQRCode(product.Id);
            Configuration.GlobalProducts.Add(product);
            return product;               
        }
        public Product CreateNewProduct(Product _product)
        {
            Product product = _product;
            product.Id = AddId(product);
            product.Qr_code_path = CreateQRCode(product.Id);
            Configuration.GlobalProducts.Add(product);
            return product;
        }

        public User ConfirmUser(string UserName, string password)
        {
            if (!GetUsers().Exists((u) => UserName == u.Name && password == u.Password))
                throw new ArgumentException("there is no such user");
           return GetUsers().Find((u) => UserName == u.Name && password == u.Password);            
        }
        public bool ConfirmManager(string UserName, string password)
        {
            return password == /*"the manager password"*/ "password";
        }
        public List<User> GetUsers()
        {
            return IDAL.GetUserList();
        }
        public List<Product> GetGlobalProducts()
        {
            return Configuration.GlobalProducts.FindAll((p)=>p.Available);
        }
        public List<Product> GetAllUserProducts(User user,Predicate<Order> predicate)
        {
            List<Order> orders = user.Orders;
            List<Product> products = new List<Product>();
            foreach (var order in orders)
            {
                if (predicate(order))
                {
                    foreach (var productId in order.ProductsIds)
                    {
                        Product efi = Product.GetProductFromId(productId);
                        AddIfNotContain(products,efi);                        
                    }
                }               
            }
            return products;
        }
        public  List<Category> GetAllCategories(User user, Predicate<Order> predicate)
        {
            List<Category> categories = new List<Category>();
            foreach (var product in GetAllUserProducts(user, predicate))
            {
                categories.Add(product.Cat);                 
            }
            return categories;
        }
        public  double GetTotalPrice(User user, Predicate<Order> predicate)
        {
            double price = 0;
            foreach (var product in GetAllUserProducts(user, predicate))
            {
                price+= product.Price;
            }
            return price;
        }
        public User GetUser(int id)
        {
            return IDAL.GetUser(id);
        }
        public Order GetOrder(User user,int id)
        {
            return IDAL.GetOrder(user, id);
        }


        public User AddUser(User user)
        {
            if (GetUsers().Exists((u) => u.Name == user.Name))
                throw new ArgumentException("This name is already exist");
            if (GetUsers().Exists((u) => u.Password == user.Password))
                throw new ArgumentException("This password is already exist"); 
            if (user.Id != Configuration.THIS_KEY_DID_NOT_INITALIZED_YET)
                throw new ArgumentException("This user is already exist");
            user.Id = AddId(user);
            IDAL.AddUser(user);
            return user;
            //throw new NotImplementedException();
        }
        public void AddOrder(User user,Order order)
        {
            if (order.ProductsIds == null)
                throw new ArgumentNullException("null products");
            if (order.Id == Configuration.THIS_KEY_DID_NOT_INITALIZED_YET)
                order.Id = AddId(order);
            foreach (var productId in order.ProductsIds)
            {
                //there is no such product in the catalog
                if (productId == Configuration.THIS_KEY_DID_NOT_INITALIZED_YET ||
                    !Product.GetProductFromId(productId).Available)
                    throw new ArgumentException("Invalid product");
            }
            IDAL.AddOrder(user, order);
        }

        public void RemoveUser(User user)
        {
            IDAL.RemoveUser(user);
        }
        public void RemoveOrder(User user, Order order)
        {
            IDAL.RemoveOrder(user,order);
        }

        // add update?

        private static void AddIfNotContain<T>(List<T> list,T item)
        {
            if (!list.Contains(item)&& item!=null)
                list.Add(item);
        }
        private int AddId(object toAdd)
        {
            if (toAdd is User)
               return ++Configuration.UserSerialKey;
            else if (toAdd is Order)
                return ++Configuration.OrderSerialKey;
            else if (toAdd is Product)                
                return ++Configuration.ProductSerialKey;              
            else
                throw new NotSupportedException("unknown object");
        }
    }
}
