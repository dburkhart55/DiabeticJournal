using DiabeticJournal.Models;
using DiabeticJournal.ViewModels.Startup;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiabeticJournal
{
    public class Database
    {
        SQLiteAsyncConnection db;

        public Database()
        {

        }

        public async Task Init()
        {
            if(db is not null)
            {
                return;

            }
            else
            {
                db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                var l = await db.CreateTableAsync<User>();
                var r = await db.CreateTableAsync<BloodRec>();
                var e = await db.CreateTableAsync<Ratio>();
                var s = await db.CreateTableAsync<Test>();
                var u = await db.CreateTableAsync<Units>();
                var t = await db.CreateTableAsync<BasalFactor>();
                var d = await db.CreateTableAsync<HBSCF>();
                setDemo();
            }

            
        }

        public async void setDemo()
        {

            

            List<User> user = new List<User>();
            user = await GetUsers();
            if (user.Count == 0)
            {
                User testUser = new User();
                testUser.FirstName = "David";
                testUser.LastName = "Schmidt";
                testUser.UserName = "DSchmidt";
                testUser.Password = LoginPageViewModel.EncryptPass("test");
                testUser.Email = "DRBVSTest@gmail.com";
                await SaveUserAsync(testUser);
            }

            List<Test> Tests = new List<Test>();
            Tests = await db.Table<Test>().ToListAsync();
            if (Tests.Count == 0)
            {
                Test Test1 = new Test();
                Test Test2 = new Test();
                Test Test3 = new Test();
                Test1.Name = "Bolus";
                Test2.Name = "Standard Check";
                Test3.Name = "High Blood Sugar Correction";
                CreateTestAsync(Test1);
                CreateTestAsync(Test2);
                CreateTestAsync(Test3);
            }

            List<Units> Unit = new List<Units>();
            Unit = await db.Table<Units>().ToListAsync();
            if (Unit.Count == 0)
            {
                Units unit = new Units();
                Units unit2 = new Units();
                unit.Name = "Imperial";
                unit.Abbreviation = "Lbs.";
                unit2.Name = "Meteric";
                unit2.Abbreviation = "Kg";

                await db.InsertAsync(unit);
                await db.InsertAsync(unit2);

            }

            List<BasalFactor> factors = new List<BasalFactor>();
            factors = await db.Table<BasalFactor>().ToListAsync();
            if (factors.Count == 0)
            {
                BasalFactor bf = new BasalFactor();
                BasalFactor bf2 = new BasalFactor();
                bf.FactorRate = .2;
                bf2.FactorRate = .3;
                
                await db.InsertAsync(bf);
                await db.InsertAsync(bf2);
            }

            List<Ratio> ratios = new List<Ratio>();
            ratios = await db.Table<Ratio>().ToListAsync();
            Console.Write(ratios);
            if(ratios.Count == 0)
            {
                TimeOnly r1st = TimeOnly.Parse("06:00:00");
                TimeOnly r1et = TimeOnly.Parse("10:00:00");
                TimeOnly r2st = TimeOnly.Parse("10:00:00");
                TimeOnly r2et = TimeOnly.Parse("14:00:00");
                TimeOnly r3st = TimeOnly.Parse("14:00:00");
                TimeOnly r3et = TimeOnly.Parse("16:00:00");
                TimeOnly r4st = TimeOnly.Parse("16:00:00");
                TimeOnly r4et = TimeOnly.Parse("20:00:00");
                TimeOnly r5st = TimeOnly.Parse("20:00:00");
                TimeOnly r5et = TimeOnly.Parse("23:59:59");
                

                Ratio r1 = new Ratio();
                Ratio r2 = new Ratio();
                Ratio r3 = new Ratio();
                Ratio r4 = new Ratio();
                Ratio r5 = new Ratio();
                r1.StartTime = r1st.ToString();
                r1.EndTime = r1et.ToString();
                r1.CarbRate = 5;
                r2.StartTime = r2st.ToString();
                r2.EndTime = r2et.ToString();
                r2.CarbRate = 3;
                r3.StartTime = r3st.ToString();
                r3.EndTime = r3et.ToString();
                r3.CarbRate = 2;
                r4.StartTime = r4st.ToString();
                r4.EndTime = r4et.ToString();
                r4.CarbRate = 5;
                r5.StartTime = r5st.ToString();
                r5.EndTime = r5et.ToString();
                r5.CarbRate = 3;
                await AddRatio(r1);
                await AddRatio(r2);
                await AddRatio(r3);
                await AddRatio(r4);
                await AddRatio(r5);

            }



        }


        public async Task<int> SaveUserAsync(User user)
        {
            try
            {
                await Init();

                if(user.Id != 0)
                {
                    var result = await db.UpdateAsync(user);
                    return result;
                }
                else
                {
                    return await db.InsertAsync(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public async Task<List<Units>> GetUnits()
        {
            await Init();
            return await db.Table<Units>().ToListAsync();
        }

        public async Task<List<BasalFactor>> GetFactors()
        {
            await Init();
            return await db.Table<BasalFactor>().ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            await Init();
            return await db.Table<User>().ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            await Init();
            List<User> users = await db.Table<User>().ToListAsync();
            foreach(var user in users)
            {
                if(user.Id == id)
                {
                    return user;
                }

            }
            return null;
        }


        public async void CreateTestAsync(Test checkType)
        {
            int result = 0;
            try
            {
                // enter this line
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(checkType.Name))
                    throw new Exception("Valid name required");

                // enter this line
                result = await db.InsertAsync(checkType);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }

        public async Task<List<Test>> GetAllTypeAsync()
        {
            try
            {
                await Init();
                var TTlist = await db.Table<Test>().ToListAsync();

                return TTlist;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return new List<Test>();
        }

        public async Task<int> AddBloodRec(BloodRec blood)
        {
            int result = 0;
            try
            {
                // enter this line
                await Init();


                // enter this line
                result = await db.InsertAsync(blood);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return result;
        }

        public async Task<List<BloodRec>> GetBloodRecsAsync()
        {

            try
            {
                await Init();

                List<BloodRec> BRList = await db.Table<BloodRec>().ToListAsync();

                return BRList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> AddRatio(Ratio ratio)
        {
            int result = 0;
            try
            {
                // enter this line
                await Init();


                // enter this line
                result = await db.InsertAsync(ratio);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return result;
        }

        public async Task<List<Ratio>> GetRatiosAsync()
        {

            try
            {
                await Init();

                List<Ratio> BRList = await db.Table<Ratio>().ToListAsync();

                return BRList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Ratio> GetRatioByTime(TimeSpan time)
        {
            var ratList = await GetRatiosAsync();

            var userId = await SecureStorage.Default.GetAsync("Logged_UserId");

            int UserId = Int32.Parse(userId);

            foreach (Ratio ratio in ratList)
            {
                if(ratio.UserId == UserId)
                {
                    string e = null;
                    string s = null;
                    ///split ratio.starttime and ratio.endtime buy " "
                    var sta = ratio.StartTime.Split(" ");
                    var eta = ratio.EndTime.Split(" ");
                    if (sta[1] == "PM")
                    {
                        var stc = sta[0].Split(":");
                        if (Int32.Parse(stc[0]) < 12)
                        {
                            var milTime = Int32.Parse(stc[0]) + 12;
                            stc[0] = milTime.ToString();
                        }

                        s = stc[0]+":"+stc[1];
                    }
                    else
                    {
                        s = sta[0];
                    }

                    if (eta[1] == "PM")
                    {
                        var etc = eta[0].Split(":");
                        if (Int32.Parse(etc[0]) < 12)
                        {
                            var eMilTime = Int32.Parse(etc[0])+12;
                            etc[0] = eMilTime.ToString();
                        }

                        e = etc[0]+":"+etc[1];
                    }
                    else
                    {
                        e = eta[0];
                    }


                    TimeSpan st = TimeSpan.Parse(s);
                    TimeSpan et = TimeSpan.Parse(e);

                    if (st < time && time < et)
                    {
                        return ratio;
                    }
                }
                
            }
            return null;

        }

        public async Task<Ratio> GetRatio(int id)
        {
            try
            {
                await Init();

                Ratio ratio = await db.Table<Ratio>().Where(v => v.Id == id).FirstOrDefaultAsync();

                return ratio;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> DeleteRatio(Ratio ratio)
        {
            try
            {
                await Init();

                return await db.DeleteAsync(ratio);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public async Task<int> UpdateRatio(Ratio ratio)
        {
            try
            {
                await Init();

                return await db.UpdateAsync(ratio);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public async Task<Units> UnitsSearch(int id)
        {
            try
            {
                await Init();
                var unitlist = await GetUnits();

                foreach(var unit in unitlist)
                {
                    if(unit.Id == id)
                    {
                        return unit;
                    }
                }

                return null;

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<BasalFactor> BasalFactorSearch(int id)
        {
            try
            {
                await Init();
                var factorlist = await GetFactors();

                foreach (var factor in factorlist)
                {
                    if (factor.Id == id)
                    {
                        return factor;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task<int> AddCF(HBSCF cf)
        {
            int result = 0;
            try
            {
                // enter this line
                await Init();


                // enter this line
                result = await db.InsertAsync(cf);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return result;
        }

        public async Task<List<HBSCF>> GetCFAsync()
        {

            try
            {
                await Init();

                List<HBSCF> CFList = await db.Table<HBSCF>().ToListAsync();

                return CFList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<HBSCF> GetCFByTime(TimeSpan time)
        {
            var cfList = await GetCFAsync();
            var userId = await SecureStorage.Default.GetAsync("Logged_UserId");

            int UserId = Int32.Parse(userId);


            foreach (HBSCF cf in cfList)
            {
                if(cf.UserId == UserId)
                {
                    string e = null;
                    string s = null;
                    ///split ratio.starttime and ratio.endtime buy " "
                    var sta = cf.StartTime.Split(" ");
                    var eta = cf.EndTime.Split(" ");
                    if (sta[1] == "PM")
                    {
                        var stc = sta[0].Split(":");
                        if (Int32.Parse(stc[0]) < 12)
                        {
                            var milTime = Int32.Parse(stc[0]) + 12;
                            stc[0] = milTime.ToString();
                        }

                        s = stc[0]+":"+stc[1];
                    }
                    else
                    {
                        s = sta[0];
                    }

                    if (eta[1] == "PM")
                    {
                        var etc = eta[0].Split(":");
                        if (Int32.Parse(etc[0]) < 12)
                        {
                            var eMilTime = Int32.Parse(etc[0])+12;
                            etc[0] = eMilTime.ToString();
                        }

                        e = etc[0]+":"+etc[1];
                    }
                    else
                    {
                        e = eta[0];
                    }


                    TimeSpan st = TimeSpan.Parse(s);
                    TimeSpan et = TimeSpan.Parse(e);

                    if (st < time && time < et)
                    {
                        return cf;
                    }
                }
                
            }
            return null;
                

        }

        public async Task<HBSCF> GetCF(int id)
        {
            try
            {
                await Init();

                HBSCF cf = await db.Table<HBSCF>().Where(v => v.Id == id).FirstOrDefaultAsync();

                return cf;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> DeleteCF(HBSCF cf)
        {
            try
            {
                await Init();

                return await db.DeleteAsync(cf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        public async Task<int> UpdateCF(HBSCF cf)
        {
            try
            {
                await Init();

                return await db.UpdateAsync(cf);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }
    }
}
