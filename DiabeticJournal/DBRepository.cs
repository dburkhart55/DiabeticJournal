using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.Startup;
using SQLite;



namespace DiabeticJournal
{

    public class DBRepository
    {
        

        public string StatusMessage { get; set; }

        readonly SQLiteAsyncConnection conn;

        /*private async Task Init()
        {
            if(conn != null)
            
                return;
            

            conn = new SQLiteAsyncConnection(Constants.DatabasePath);
            var result = await conn.CreateTableAsync<User>();
            result = await conn.CreateTableAsync<BloodRec>();
            result = await conn.CreateTableAsync<Test>();
            result = await conn.CreateTableAsync<Ratio>();

            

            
        }*/

        public DBRepository(string dbPath)
        {
            
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<User>().Wait();
            conn.CreateTableAsync<BloodRec>().Wait();
            conn.CreateTableAsync<Ratio>().Wait();
            conn.CreateTableAsync<Test>().Wait();

           


           setDemo();
            

        }

        public async void setDemo()
        {

            DBRepository db = new DBRepository(Constants.DatabasePath);
           
            List<User> user = new List<User>();
            user = await db.GetUsersAsync();
            if(user.Count == 0) 
            {
                User testUser = new User();
                testUser.FirstName = "David";
                testUser.LastName = "Schmidt";
                testUser.UserName = "DSchmidt";
                testUser.Password = LoginPageViewModel.EncryptPass("test");
                testUser.Email = "DRBVSTest@gmail.com";
                db.CreateUserAsync(testUser);
            }

            List<Test> Tests = new List<Test>();
            Tests = await conn.Table<Test>().ToListAsync();
            if(Tests.Count == 0)
            {
                Test Test1 = new Test();
                Test Test2 = new Test();
                Test Test3 = new Test();
                Test1.Name = "Bolus";
                Test2.Name = "Standard Check";
                Test3.Name = "High Blood Sugar Correction";
                db.CreateTypeAsync(Test1);
                db.CreateTypeAsync(Test2);
                db.CreateTypeAsync(Test3);
            }


    
        }

        

        /**********************************************************************************
         * Create all database functions for Tests
         * CreateTypeAsync
         * 
         * ********************************************************************************/

        public async void CreateTestAsync(Test checkType)
        {
            int result = 0;
            try
            {
                // enter this line
                //await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(checkType.Name))
                    throw new Exception("Valid name required");

                // enter this line
                result = await conn.InsertAsync(checkType);


            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);

            }
            

        }

        public async Task<List<Test>> GetAllTypeAsync()
        {
            try
            {
                
                var TTlist =  await conn.Table<Test>().ToListAsync();

                return TTlist;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);

            }

            return new List<Test>();
        }

        public async Task<int> AddBloodRec(BloodRec blood)
        {
            int result = 0;
            try
            {
                // enter this line
                //await Init();


                // enter this line
                result = await conn.InsertAsync(blood);
                


            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);

            }

            return result;
        }

        public async Task<List<BloodRec>> GetBloodRecsAsync()
        {
           
            try
            {
                //await Init();

                List<BloodRec> BRList = await conn.Table<BloodRec>().ToListAsync();

                return BRList;
            }
            catch(Exception ex)
            {
                StatusMessage = String.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<BloodRec>();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> users = new List<User>();
            try
            {
                users = await conn.Table<User>().ToListAsync();

                Console.WriteLine(users.Count);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return users;
        }

        public async void CreateUserAsync(User user)
        {
            try
            {
                conn.InsertAsync(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
