using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        //Business Rules Messages
        public static string ProductAmountInCertainCategoryError = "The Amount Of Products Are Restricted In This Category";
        public static string ProductNameAlreadyExists = "This Product Has Already Added";
        public static string CategoryAmountError = "Risked Category Amount Exceed. To Protect Owner System Will Not Accept New Product. Please Contact Provider";
        //-------------------------------------------------------------------------------------------------------


        //Product Messages
        public static string ProductAdded = "Product Added Successfully";
        public static string ProductCouldNotAdded = "Product Could Not Added Something Went Wrong";

        public static string ProductDeleted = "Product Deleted Successfully";
        public static string ProductCouldNotDeleted = "Product Could Not Added Something Went Wrong";

        public static string ProductUpdated = "Product Updated Successfully";
        public static string ProductCouldNotUpdated = "Product Could Not Added Something Went Wrong";

        public static string ProductsCouldNotListed = "Products Could Not Listed Something Went Wrong";
        public static string ProductsListed = "Products Listed Successfully";

        public static string ProductsListedFilter = "Products Listed According To The User Filters";
        public static string ProductsCouldNotListedFilter = "No Results Found According To The User Filters";

        public static string ProductRecievedFilter = "Product Recieved According To The User Filters";
        public static string ProductCouldNotRecievedFilter = "No Result Found According To The User Filters";

        public static string ProductsSold = "Products Sold";
        public static string ProductsCouldNotSold = "Products Could Not Sold";

        public static string CriticalStockAmount = "The Stock Amount Of The Product Is In The Critical Level";
        public static string NotEnoughStock = "There Is Not Enough Stock For The Specified Amount Of Sales";

        public static string SystemMaintenanceTime = "System In Maintenance";

        //-------------------------------------------------------------------------------------------------------


        //Category Messages
        public static string CategoryAdded = "Category Added Successfully";
        public static string CategoryCouldNotAdded = "Category Could Not Added Something Went Wrong";

        public static string CategoryDeleted = "Category Deleted Successfully";
        public static string CategoryCouldNotDeleted = "Category Could Not Deleted Something Went Wrong";

        public static string CategoryUpdated = "Category Updated Successfully";
        public static string CategoryCouldNotUpdated = "Category Could Not Updated Something Went Wrong";

        public static string CategoriesListed = "Categories Listed Successfully";
        public static string CategoriesCouldNotListed = "Categories Could Not Listed Something Went Wrong";

        public static string CategoriesListedFilter = "Categories Listed According To The User Filters";
        public static string CategoriesCouldNotListedFilter = "No Results Found According To The User Filters";

        public static string CategoryRecievedFilter = "Category Recieved According To The User Filters";
        public static string CategroyCouldNotRecievedFilter = "No Result Found According To The User Filters";

        //-------------------------------------------------------------------------------------------------------


        //Customer Messages
        public static string CustomerAdded = "Customer Added Successfully";
        public static string CustomerCouldNotAdded = "Customer Could Not Added Something Went Wrong";

        public static string CustomerDeleted = "Customer Deleted Successfully";
        public static string CustomerCouldNotDeleted = "Customer Could Not Deleted Something Went Wrong";

        public static string CustomerUpdated = "Customer Updated Successfully";
        public static string CustomerCouldNotUpdated = "Customer Could Not Updated Something Went Wrong";

        public static string CustomersListed = "Customers Listed Successfully";
        public static string CustomersCouldNotListed = "Customers Could Not Listed Something Went Wrong";

        public static string CustomersListedFilter = "Customers Listed According To The User Filters";
        public static string CustomersCouldNotListedFilter = "No Results Found According To The User Filters";

        public static string CustomerRecievedFilter = "Customer Recieved According To The User Filters";
        public static string CustomerCouldNotRecievedFilter = "No Result Found According To The User Filters";

        //-------------------------------------------------------------------------------------------------------


        //UserMessages

        public static string UserAdded = "User Added";
        public static string UserDeleted = "User Deleted";
        public static string UserUpdated = "User Updated";
        public static string UsersCouldNotListed = "Users Could Not Listed";
        public static string ClaimsCouldNotListed = "Claims Could Not Listed";
        public static string UserNotFound = "User Not Found";

        //-------------------------------------------------------------------------------------------------------


        //AuthorizationMessages

        public static string AuthorizationDenied = "Authorization Denied";
        public static string AccessTokenCreated = "Access Token Created";
        //-------------------------------------------------------------------------------------------------------


        //AuthenticationMessages
        public static string LoggedInSuccessfully = "Login Successful";
        public static string RegisteredSuccessfully = "Registered Successfully";
        public static string UserNotVerified = "User Not Verified";

        //-------------------------------------------------------------------------------------------------------


        //SystemRouting
        public static string SystemLockedUntil()
        {
            return "System Locked For A While";
        }
        public static string SystemLockedUntil(DateTime unlockingDate)
        {
            return "System Locked Until" + unlockingDate.ToString();
        }

    }
}
