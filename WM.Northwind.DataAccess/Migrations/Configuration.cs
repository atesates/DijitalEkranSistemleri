using System.Collections.Generic;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.SqlServer;
    using System.Data.Entity.Validation;
    using System.Linq;
    using WM.Northwind.Entities.Concrete.Authorization;
    using WM.Northwind.Entities.Concrete.EczaneNobet;

    internal sealed class Configuration : DbMigrationsConfiguration<WM.Northwind.DataAccess.Concrete.EntityFramework.Contexts.EczaneNobetContext>
    {
        public Configuration()//OnModelCreating de  //modelBuilder.HasDefaultSchema("EczaneNobet"); yi açýklama satýrý yap
        {
            //veri tabanýnda deðiþikliðe izin vermek için istendiði zaman true olacak.
            AutomaticMigrationsEnabled = false;
            //alan silineceði zaman true olacak. silmede veri kaybýný önlemek için false 
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(WM.Northwind.DataAccess.Concrete.EntityFramework.Contexts.EczaneNobetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //bool guncelle = false;
            bool masterGuncelle = false;

            //if (guncelle)
            //{
            //    VeriEkleGuncelle(context);
            //}
            if (masterGuncelle)
            {
                VeriEkleGuncelleMaster(context);
            }
        }
        private static void VeriEkleGuncelle(Concrete.EntityFramework.Contexts.EczaneNobetContext context)
        {

         

        }
        private static void VeriEkleGuncelleMaster(Concrete.EntityFramework.Contexts.EczaneNobetContext context)
        {
            #region users
            var User = new List<User>()
                            {
            new User(){ Email="cihaz@cihaz.com", FirstName="cihaz", LastName="cihaz", Password="123456", UserName="cihaz"},
            new User(){ Email="atesates2012@gmail.com", FirstName="Ateþ", LastName="Ateþ", Password="123456", UserName="ates"},
            new User(){ Email="ozdamar85@gmail.com", FirstName="Semih", LastName="ÖZDAMAR", Password="123456", UserName="semih"},
            new User(){ Email="yusuf@nobetcieczanesistemi.com", FirstName="Yusuf", LastName="Taze", Password="123456", UserName="yusuf"},
            new User(){ Email="safak@nobetcieczanesistemi.com", FirstName="Þafak", LastName="Demir", Password="123456", UserName="safak"},
            //6,7,8,9
            new User(){ Email="grupMersin@nobetcieczanesistemi.com", FirstName="grupMersin", LastName="nobetcieczanesistemi", Password="123456", UserName="grupMersin"},
            new User(){ Email="grupZonguldak@nobetcieczanesistemi.com", FirstName="grupZonguldak", LastName="nobetcieczanesistemi", Password="123456", UserName="grupZonguldak"},
            new User(){ Email="grupÝskenderun@nobetcieczanesistemi.com", FirstName="grupÝskenderun", LastName="nobetcieczanesistemi", Password="123456", UserName="grupÝskenderun"},
            new User(){ Email="grupOsmaniye@nobetcieczanesistemi.com", FirstName="grupOsmaniye", LastName="nobetcieczanesistemi", Password="123456", UserName="grupOsmaniye"},
            //10,11,12,13
            new User(){ Email="eczalikocak@gmail.com", FirstName="Ali", LastName="Koçak", Password="Mersin2018", UserName="AliKoçak"},
            new User(){ Email="eczonurazman@hotmail.com", FirstName="Onur", LastName="Azman", Password="zeonur1", UserName="OnurAzman"},
            new User(){ Email="oncelnilgun@gmail.com", FirstName="Nilgün", LastName="Öncel", Password="HeoNilgun", UserName="NilgünÖncel"},
            new User(){ Email="mustafatopalecz@hotmail.com", FirstName="Mustafa", LastName="Topal", Password="48OeoMustafa", UserName="MustafaTopal"},
            //14,15
            new User(){ Email="merveates2012@gmail.com", FirstName="Merve", LastName="Ateþ", Password="123456", UserName="MerveAteþ"},
            new User(){ Email="defitenis@gmail.com", FirstName="defi", LastName="Ateþ", Password="123456", UserName="DefiAteþ"},

            };

            context.Users.AddOrUpdate(s => new { s.Email }, User.ToArray());
            try
            {

                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            #endregion

            #region gruplar
            var Grup = new List<Grup>()
                            {
            new Grup(){ Adi = "Demo" },
            new Grup(){ Adi = "Mersin" },
            new Grup(){ Adi = "Zonguldak" },
            new Grup(){ Adi = "Ýskenderun" },
            new Grup(){ Adi = "Osmaniye" },

            };

            context.Gruplar.AddOrUpdate(s => new { s.Adi }, Grup.ToArray());
            context.SaveChanges();
            #endregion

            #region grup userlar
            var grupUser = new List<GrupUser>()
                            {
                                new GrupUser(){ GrupId=1, UserId=1 },
                                new GrupUser(){ GrupId=1, UserId=2 },
                                new GrupUser(){ GrupId=1, UserId=3 },
                                new GrupUser(){ GrupId=1, UserId=4 },
                                new GrupUser(){ GrupId=1, UserId=5 },

                                new GrupUser(){ GrupId=2, UserId=6 },
                                new GrupUser(){ GrupId=3, UserId=7 },
                                new GrupUser(){ GrupId=4, UserId=8 },
                                new GrupUser(){ GrupId=5, UserId=9 },

                                new GrupUser(){ GrupId=2, UserId=10 },
                                new GrupUser(){ GrupId=3, UserId=11 },
                                new GrupUser(){ GrupId=4, UserId=12 },
                                new GrupUser(){ GrupId=5, UserId=13 },

                                new GrupUser(){ GrupId=1, UserId=14 },
                                new GrupUser(){ GrupId=1, UserId=15 },
                            };

            context.GrupUserlar.AddOrUpdate(s => new { s.GrupId, s.UserId }, grupUser.ToArray());
            context.SaveChanges();
            #endregion

            #region roles
            var Role = new List<Role>()
                            {
                                new Role(){ Name="Cihaz" },
                                new Role(){ Name="Admin" },
                                new Role(){ Name="Grup Yönetici" },
                                new Role(){ Name="Grup Onay" },
                                new Role(){ Name="Grup Kullanici" },
                                new Role(){ Name="Kullanici" },
                            };

            context.Roles.AddOrUpdate(s => new { s.Name }, Role.ToArray());
            //vRole.ForEach(d => context.Roles.Add(d));
            context.SaveChanges();
            #endregion

            #region user roles
            var vuserRole = new List<UserRole>()
                            {
                                new UserRole(){ RoleId=1, UserId=1 },

                                new UserRole(){ RoleId=2, UserId=2 },
                                new UserRole(){ RoleId=2, UserId=3 },
                                new UserRole(){ RoleId=2, UserId=4 },
                                new UserRole(){ RoleId=2, UserId=5 },

                                new UserRole(){ RoleId=3, UserId=6 },
                                new UserRole(){ RoleId=3, UserId=7 },
                                new UserRole(){ RoleId=3, UserId=8 },
                                new UserRole(){ RoleId=3, UserId=9 },

                                new UserRole(){ RoleId=3, UserId=10 },
                                new UserRole(){ RoleId=3, UserId=11 },
                                new UserRole(){ RoleId=3, UserId=12 },
                                new UserRole(){ RoleId=3, UserId=13 },

                                new UserRole(){ RoleId=5, UserId=14 },
                                new UserRole(){ RoleId=4, UserId=14 },


                            };

            context.UserRoles.AddOrUpdate(s => new { s.RoleId, s.UserId }, vuserRole.ToArray());
            context.SaveChanges();
            #endregion

            #region menüler
            var Menu = new List<Menu>()
            {
            //Menü Single Items 1
            //new Menu(){ LinkText="Ekran", SpanCssClass="fa fa-desktop fa-lg" },

            new Menu(){ LinkText="Ekran", ActionName="Index", ControllerName="Ekran", AreaName="EczaneNobet", SpanCssClass="fa fa-desktop fa-lg" },
            new Menu(){ LinkText="Tasarým", ActionName="Index", ControllerName="EkranTasarim", AreaName="EczaneNobet", SpanCssClass="fa fa-paint-brush fa-lg" },
            new Menu(){ LinkText="Ýçerik", ActionName="Index", ControllerName="EkranIcerik", AreaName="EczaneNobet", SpanCssClass="fa fa-image fa-lg" },
            new Menu(){ LinkText="Konum", ActionName="Index", ControllerName="Konum", AreaName="EczaneNobet", SpanCssClass="fa fa-globe fa-lg" },
            new Menu(){ LinkText="Cihaz", ActionName="Index", ControllerName="Cihaz", AreaName="EczaneNobet", SpanCssClass="fa fa-microchip fa-lg" },
            new Menu(){ LinkText="Monitor", ActionName="Index", ControllerName="Monitor", AreaName="EczaneNobet", SpanCssClass="fa fa-tv fa-lg" },

            new Menu(){ LinkText="Yetki", SpanCssClass="fa fa-shield" }
            };

            context.Menuler.AddOrUpdate(s => new { s.LinkText }, Menu.ToArray());
            //vMenu.ForEach(d => context.Menuler.Add(d));
            context.SaveChanges();
            #endregion

            #region menü roller

            var vMenuRole = new List<MenuRole>()
                            {
                                //cihaz 
                                new MenuRole(){ MenuId=1, RoleId=1 },
                                new MenuRole(){ MenuId=2, RoleId=1 },
                                new MenuRole(){ MenuId=3, RoleId=1 },
                                new MenuRole(){ MenuId=4, RoleId=1 },
                                new MenuRole(){ MenuId=5, RoleId=1 },
                                new MenuRole(){ MenuId=6, RoleId=1 },
                                new MenuRole(){ MenuId=7, RoleId=1 },
                                
                                //admin
                                new MenuRole(){ MenuId=1, RoleId=2 },
                                new MenuRole(){ MenuId=2, RoleId=2 },
                                new MenuRole(){ MenuId=3, RoleId=2 },
                                new MenuRole(){ MenuId=4, RoleId=2 },
                                new MenuRole(){ MenuId=5, RoleId=2 },
                                new MenuRole(){ MenuId=6, RoleId=2 },
                                new MenuRole(){ MenuId=7, RoleId=2 },

                                //Grup Yönetici 
                                new MenuRole(){ MenuId=1, RoleId=3 },
                                new MenuRole(){ MenuId=2, RoleId=3 },
                                new MenuRole(){ MenuId=3, RoleId=3 },
                                new MenuRole(){ MenuId=4, RoleId=3 },
                                new MenuRole(){ MenuId=5, RoleId=3 },
                                new MenuRole(){ MenuId=6, RoleId=3 },
                                new MenuRole(){ MenuId=7, RoleId=3 },


                                 //Grup Onay                                
                                new MenuRole(){ MenuId=1, RoleId=4 },
                                new MenuRole(){ MenuId=2, RoleId=4 },
                                new MenuRole(){ MenuId=3, RoleId=4 },
                                new MenuRole(){ MenuId=4, RoleId=4 },
                                new MenuRole(){ MenuId=5, RoleId=4 },
                                new MenuRole(){ MenuId=6, RoleId=4 },

                                //Grup Kullanici
                                new MenuRole(){ MenuId=1, RoleId=5 },
                                new MenuRole(){ MenuId=2, RoleId=5 },
                                new MenuRole(){ MenuId=3, RoleId=5 },
                                new MenuRole(){ MenuId=4, RoleId=5 },
                                new MenuRole(){ MenuId=5, RoleId=5 },
                                new MenuRole(){ MenuId=6, RoleId=5 },

                            };

            context.MenuRoles.AddOrUpdate(s => new { s.MenuId, s.RoleId }, vMenuRole.ToArray());
            //vMenuRole.ForEach(d => context.MenuRoles.Add(d));
            context.SaveChanges();

            #endregion

            #region menü altlar
            var vMenuAlt = new List<MenuAlt>()
            {
                //1,2,3
                //new MenuAlt(){ LinkText="Ekran Listesi", ActionName="Index", ControllerName="Ekran", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=1},
                //new MenuAlt(){ LinkText="Ekran Planlama", ActionName="Index", ControllerName="YayinEkran", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=1},
                //new MenuAlt(){ LinkText="Ýçerik Durumu", ActionName="Index", ControllerName="YayinEkranIcerik", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=1},

                //new MenuAlt(){ LinkText="Ekran", ActionName="Index", ControllerName="Ekran", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=1 },
                //new MenuAlt(){ LinkText="Ekran Tasarým", ActionName="Index", ControllerName="EkranTasarim", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=1 },
              
                //4,5,6, 7,8,9, 10,11,12,13,14
                new MenuAlt(){ LinkText="Çözünürlük", ActionName="Index", ControllerName="Cozunurluk", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7 },
                new MenuAlt(){ LinkText="Cihaz Durum", ActionName="Index", ControllerName="CihazDurum", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7 },
                new MenuAlt(){ LinkText="Kullanýcý", ActionName="Register", ControllerName="Account", AreaName="", SpanCssClass="dropdown-item", MenuId=7},

                new MenuAlt(){ LinkText="Menü", ActionName="Index", ControllerName="Menu", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},
                new MenuAlt(){ LinkText="Menü Alt", ActionName="Index", ControllerName="MenuAlt", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},
                new MenuAlt(){ LinkText="Menü Rol", ActionName="Index", ControllerName="MenuRole", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},

                new MenuAlt(){ LinkText="Menü Alt Rol", ActionName="Index", ControllerName="MenuAltRole", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},
                new MenuAlt(){ LinkText="Rol", ActionName="Index", ControllerName="Role", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},
                new MenuAlt(){ LinkText="Kullanýcý Rol", ActionName="Index", ControllerName="UserRole", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},

                new MenuAlt(){ LinkText="Grup", ActionName="Index", ControllerName="Grup", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},
                new MenuAlt(){ LinkText="Grup Kullanýcý", ActionName="Index", ControllerName="GrupUser", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},

                new MenuAlt(){ LinkText="Yayýnlanan Ekranlar", ActionName="Index", ControllerName="YayinEkran", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},
                new MenuAlt(){ LinkText="Yayýnlanan Ýçerikler", ActionName="Index", ControllerName="YayinEkranIcerik", AreaName="EczaneNobet", SpanCssClass="dropdown-item", MenuId=7},


                };

            context.MenuAltlar.AddOrUpdate(s => new { s.LinkText }, vMenuAlt.ToArray());
            //vMenuAlt.ForEach(d => context.MenuAltlar.Add(d));
            context.SaveChanges();

            #endregion

            #region menü alt roller

            var MenuAltRole = new List<MenuAltRole>()
                            {   
                                #region admin
		                        new MenuAltRole(){ MenuAltId=1, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=2, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=3, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=4, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=5, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=6, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=7, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=8, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=9, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=10, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=11, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=12, RoleId=2 },
                                new MenuAltRole(){ MenuAltId=13, RoleId=2 },
                               // new MenuAltRole(){ MenuAltId=13, RoleId=2 },
                               // new MenuAltRole(){ MenuAltId=14, RoleId=2 },
	                            #endregion
                                
                                #region yönetici
                                new MenuAltRole(){ MenuAltId=3, RoleId=3 },
                                new MenuAltRole(){ MenuAltId=9, RoleId=3 },

                                new MenuAltRole(){ MenuAltId=12, RoleId=3 },
                                new MenuAltRole(){ MenuAltId=13, RoleId=3 },
                               // new MenuAltRole(){ MenuAltId=1, RoleId=3 },
                                //new MenuAltRole(){ MenuAltId=2, RoleId=3 },
                                //new MenuAltRole(){ MenuAltId=3, RoleId=3 },
	                            #endregion
                                
                                #region kullanici
	                            #endregion
                            };

            context.MenuAltRoles.AddOrUpdate(s => new { s.MenuAltId, s.RoleId }, MenuAltRole.ToArray());
            //vMenuAltRole.ForEach(d => context.MenuAltRoles.Add(d));
            context.SaveChanges();
            #endregion

            #region cozunurlukler
            var Cozunurlukler = new List<Cozunurluk>()
                            {
            new Cozunurluk(){ Aciklama = "Oda Kanitindeki ile ayný kalitede", Deger="1360-768",Adi = "Hd 1360-768" },

            };

            context.Cozunurlukler.AddOrUpdate(s => new { s.Id }, Cozunurlukler.ToArray());
            context.SaveChanges();
            #endregion

            #region konumlar
            var Konumlar = new List<Konum>()
                            {
            new Konum(){Adi="Hayat Hastanesi Acil Giriþi", Aciklama = "",Boylam = 36.56778, Enlem = 34.5643, BaslamaTarihi=System.DateTime.Today, GrupId=5 },
            new Konum(){Adi="Hayat Hastanesi Kantin", Aciklama = "",Boylam = 36.56878, Enlem = 34.5623, BaslamaTarihi=System.DateTime.Today, GrupId=5 },
            new Konum(){Adi="Hayat Hastanesi Danýþma", Aciklama = "",Boylam = 36.56678, Enlem = 34.5643, BaslamaTarihi=System.DateTime.Today, GrupId=5 },

            new Konum(){Adi="Özen Hastanesi Acil Giriþi", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=4 },
            new Konum(){Adi="Özen Hastanesi Kantin", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=4 },
            new Konum(){Adi="Özen Hastanesi Danýþma", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=4 },

            new Konum(){Adi="Yaþam Hastanesi Acil Giriþi", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=3 },
            new Konum(){Adi="Yaþam Hastanesi Kantin", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=3 },
            new Konum(){Adi="Yaþam Hastanesi Danýþma", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=3 },

            new Konum(){Adi="Ömür Hastanesi Acil Giriþi", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=2 },
            new Konum(){Adi="Ömür Hastanesi Kantin", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=2 },
            new Konum(){Adi="Ömür Hastanesi Danýþma", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=2 },

            new Konum(){Adi="Ateþ'in Yeri", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=1 },
            new Konum(){Adi="Semih'in Yeri", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=1 },
            new Konum(){Adi="Yusuf'un Yeri", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=1 },
            new Konum(){Adi="Þafak'ýn Yeri", Aciklama = "",Boylam = 36.56978, Enlem = 34.5613, BaslamaTarihi=System.DateTime.Today, GrupId=1 },


            };

            context.Konumlar.AddOrUpdate(s => new { s.Id }, Konumlar.ToArray());
            context.SaveChanges();
            #endregion

            #region cihazDurumlar
            var CihazDurumlar = new List<CihazDurum>()
                            {
            new CihazDurum(){ Aciklama = "Cihaz sýkýntýsýz çalýþýyor", Adi="Aktif", RoleId=5 },
            new CihazDurum(){ Aciklama = "", Adi="Sayfayý yenile", RoleId=5  },
            new CihazDurum(){ Aciklama = "", Adi="Sayfayý baþtan baþlat", RoleId=5  },
            new CihazDurum(){ Aciklama = "", Adi="Cihazý yeniden baþlat", RoleId=5 },
            new CihazDurum(){ Aciklama = "", Adi="Domain deðiþti", RoleId=2 },
            new CihazDurum(){ Aciklama = "", Adi="Wifi deðiþti", RoleId=5  },
            new CihazDurum(){ Aciklama = "", Adi="Cihaz güncellenmeli", RoleId=2  },


            };

            context.CihazDurumlar.AddOrUpdate(s => new { s.Id }, CihazDurumlar.ToArray());
            context.SaveChanges();
            #endregion

            #region cihazlar
            var Cihazlar = new List<Cihaz>()
                            {
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v151", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=5, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/1" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v152", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=5, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/2" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v153", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=5, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/3" },

            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v154", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=4, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/4" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v155", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=4, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/5" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v156", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=4, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/6" },

            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v157", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=3, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/7" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v158", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today ,GrupId=3, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/8" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v159", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=3, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/9" },

            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v160", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=2, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2 , ApiUrl="https://api.nobetyaz.com/ekranlar/10"},
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v161", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=2, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2 , ApiUrl="https://api.nobetyaz.com/ekranlar/11"},
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v162", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=2, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2 , ApiUrl="https://api.nobetyaz.com/ekranlar/12"},

            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v163", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=1, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/13" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v164", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=1, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/14" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v165", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=1, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/15" },
            new Cihaz(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, PingPeriyodu=1, Marka="Raspery",Model="Pi 3",SeriNu="124141v166", CihazDurumId = 1, BaslamaTarihi=System.DateTime.Today, GrupId=1, SonGuncellenmeTarihi=System.DateTime.Today, SonGuncelleyenUserId=2, ApiUrl="https://api.nobetyaz.com/ekranlar/16" },
            };

            context.Cihazlar.AddOrUpdate(s => new { s.Id }, Cihazlar.ToArray());
            context.SaveChanges();
            #endregion

            #region monitorler
            var Monitorler = new List<Monitor>()
                            {
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v151", BoyutuInc=22,Adi="Monitor1", BaslamaTarihi=System.DateTime.Today, GrupId=5 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v152", BoyutuInc=22,Adi="Monitor2", BaslamaTarihi=System.DateTime.Today, GrupId=5 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v153", BoyutuInc=22,Adi="Monitor3", BaslamaTarihi=System.DateTime.Today, GrupId=5 },


            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v156", BoyutuInc=22,Adi="Monitor1", BaslamaTarihi=System.DateTime.Today, GrupId=4 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v157", BoyutuInc=22,Adi="Monitor2", BaslamaTarihi=System.DateTime.Today, GrupId=4 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v159", BoyutuInc=22,Adi="Monitor3", BaslamaTarihi=System.DateTime.Today, GrupId=4 },

            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v154", BoyutuInc=22,Adi="Monitor1", BaslamaTarihi=System.DateTime.Today, GrupId=3 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v155", BoyutuInc=22,Adi="Monitor2", BaslamaTarihi=System.DateTime.Today, GrupId=3 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v158", BoyutuInc=22,Adi="Monitor3", BaslamaTarihi=System.DateTime.Today, GrupId=3 },


            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v160", BoyutuInc=22,Adi="Monitor1", BaslamaTarihi=System.DateTime.Today, GrupId=2 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v161", BoyutuInc=22,Adi="Monitor2", BaslamaTarihi=System.DateTime.Today, GrupId=2 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v162", BoyutuInc=22,Adi="Monitor3", BaslamaTarihi=System.DateTime.Today, GrupId=2 },


            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v163", BoyutuInc=22,Adi="Monitor1", BaslamaTarihi=System.DateTime.Today, GrupId=1 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v164", BoyutuInc=22,Adi="Monitor2", BaslamaTarihi=System.DateTime.Today, GrupId=1 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v165", BoyutuInc=22,Adi="Monitor3", BaslamaTarihi=System.DateTime.Today, GrupId=1 },
            new Monitor(){ Aciklama = "",AlimTarihi=System.DateTime.Today,CozunurlukId=1, Marka="LG",SeriNu="1AEG1v166", BoyutuInc=22,Adi="Monitor4", BaslamaTarihi=System.DateTime.Today, GrupId=1 },


            };

            context.Monitorler.AddOrUpdate(s => new { s.Id }, Monitorler.ToArray());
            context.SaveChanges();
            #endregion

            #region ekranTasarimlar
            var EkranTasarimlar = new List<EkranTasarim>()
                            {
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=5,Adi="EkranTasarimim1",SonDegisiklikTarihi=System.DateTime.Today },
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=5,Adi="EkranTasarimim2",SonDegisiklikTarihi=System.DateTime.Today },


                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=4,Adi="EkranTasarimim1",SonDegisiklikTarihi=System.DateTime.Today },
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=4,Adi="EkranTasarimim2",SonDegisiklikTarihi=System.DateTime.Today },

                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=3,Adi="EkranTasarimim1",SonDegisiklikTarihi=System.DateTime.Today },
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=3,Adi="EkranTasarimim2",SonDegisiklikTarihi=System.DateTime.Today },

                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=2,Adi="EkranTasarimim1",SonDegisiklikTarihi=System.DateTime.Today },
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=2,Adi="EkranTasarimim2",SonDegisiklikTarihi=System.DateTime.Today },


                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=1,Adi="EkranTasarimim1",SonDegisiklikTarihi=System.DateTime.Today },
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=1,Adi="EkranTasarimim2",SonDegisiklikTarihi=System.DateTime.Today },
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=1,Adi="EkranTasarimim3",SonDegisiklikTarihi=System.DateTime.Today },
                new EkranTasarim(){ Aciklama = "", BaslamaTarihi=System.DateTime.Today,GrupId=1,Adi="EkranTasarimim4",SonDegisiklikTarihi=System.DateTime.Today },

            };

            context.EkranTasarimlar.AddOrUpdate(s => new { s.Id }, EkranTasarimlar.ToArray());
            context.SaveChanges();
            #endregion

            #region ekranIcerikler
            var EkranIcerikler = new List<EkranIcerik>()
                            {

            new EkranIcerik(){ GrupId = 5, Adi="Nöbetçi Eczaneler Ekraný dar", Uzanti="html", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 5, Adi="dikey reklam", Uzanti="png", Url="~/Content/images/EkranIcerik/2" },
            new EkranIcerik(){ GrupId = 5, Adi="Nöbetçi Eczaneler Ekraný geniþ", Uzanti="video", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 5, Adi="yatay reklam", Uzanti="video", Url="~/Content/images/EkranIcerik/4" },


            new EkranIcerik(){ GrupId = 4, Adi="Nöbetçi Eczaneler Ekraný dar ", Uzanti="html", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 4, Adi="dikey reklam", Uzanti="png", Url="~/Content/images/EkranIcerik/6" },
            new EkranIcerik(){ GrupId = 4, Adi="Nöbetçi Eczaneler Ekraný geniþ", Uzanti="video", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 4, Adi="yatay reklam",  Uzanti="video", Url="~/Content/images/EkranIcerik/8" },


            new EkranIcerik(){ GrupId = 3, Adi="Nöbetçi Eczaneler Ekraný dar",  Uzanti="html", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 3, Adi="dikey reklam", Uzanti="png", Url="~/Content/images/EkranIcerik/10" },
            new EkranIcerik(){ GrupId = 3, Adi="Nöbetçi Eczaneler Ekraný geniþ", Uzanti="video", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 3, Adi="yatay reklam",  Uzanti="video", Url="~/Content/images/EkranIcerik/12" },

            new EkranIcerik(){ GrupId = 2, Adi="Nöbetçi Eczaneler Ekraný dar",  Uzanti="html", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 2, Adi="dikey reklam",  Uzanti="png", Url="~/Content/images/EkranIcerik/14" },
            new EkranIcerik(){ GrupId = 2, Adi="Nöbetçi Eczaneler Ekraný geniþ",  Uzanti="video", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 2, Adi="yatay reklam",  Uzanti="video", Url="~/Content/images/EkranIcerik/16" },


            new EkranIcerik(){ GrupId = 1, Adi="Nöbetçi Eczaneler Ekraný", Uzanti="html", Url="https://nobetyaz.com/onee/1" },
            new EkranIcerik(){ GrupId = 1, Adi="Aptamil Raklamý",  Uzanti="png", Url="~/Content/images/EkranIcerik/18" },
            new EkranIcerik(){ GrupId = 1, Adi="bebelak youtube 1",  Uzanti="video", Url="https://www.youtube.com/embed/htJMOBf73AU" },
            new EkranIcerik(){ GrupId = 1, Adi="Reklam 2 Bruno",  Uzanti="video", Url="https://www.youtube.com/embed/Lk87pHrlc_4" },

            new EkranIcerik(){ GrupId = 1, Adi="reklam 3 Roche",  Uzanti="video", Url="https://www.youtube.com/embed/tXJUAAlv67Y" },
            new EkranIcerik(){ GrupId = 1, Adi="Blendax Raklamý",  Uzanti="png", Url="~/Content/images/EkranIcerik/22" },
            new EkranIcerik(){ GrupId = 1, Adi="Aspirin Reklamý",  Uzanti="video", Url="https://www.youtube.com/embed/Ye6VthNLzhU" },
            new EkranIcerik(){ GrupId = 1, Adi="reklam 4 Bepanthol",  Uzanti="video", Url="https://www.youtube.com/embed/Lk87pHrlc_4" },

            new EkranIcerik(){ GrupId = 1, Adi="Nöbetçi Eczaneler Ekraný",  Uzanti="video", Url="https://nobetyaz.com/eczanenobet/nobetcieczaneekrani" },
            new EkranIcerik(){ GrupId = 1, Adi="Diþ reklamý",  Uzanti="png", Url="~/Content/images/EkranIcerik/26" },
            new EkranIcerik(){ GrupId = 1, Adi="Kamu Spotu - Sigarayý býrak hayatý býrakma", Uzanti="video", Url="https://www.youtube.com/embed/RIhoeMl5uvU" },
            new EkranIcerik(){ GrupId = 1, Adi="Reklam 2 Bruno",  Uzanti="video", Url="https://www.youtube.com/embed/Lk87pHrlc_4" },


            };

            context.EkranIcerikler.AddOrUpdate(s => new { s.Id }, EkranIcerikler.ToArray());
            context.SaveChanges();
            #endregion

            #region ekranlar
            var Ekranlar = new List<Ekran>()
                            {
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/1",BaslamaTarihi=System.DateTime.Today, CihazId =1, KonumId=1,MonitorId =1,GrupId=5 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/2",BaslamaTarihi=System.DateTime.Today, CihazId =2, KonumId=2,MonitorId =2,GrupId=5 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/3",BaslamaTarihi=System.DateTime.Today, CihazId =3, KonumId=3,MonitorId =3,GrupId=5 },

            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/7",BaslamaTarihi=System.DateTime.Today, CihazId =4, KonumId=4,MonitorId =4,GrupId=4 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/8",BaslamaTarihi=System.DateTime.Today, CihazId =5, KonumId=5,MonitorId =5,GrupId=4 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/9",BaslamaTarihi=System.DateTime.Today, CihazId =6, KonumId=6,MonitorId =6,GrupId=4 },


            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/4",BaslamaTarihi=System.DateTime.Today, CihazId =7, KonumId=7,MonitorId =7,GrupId=3 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/5",BaslamaTarihi=System.DateTime.Today, CihazId =8, KonumId=8,MonitorId =8,GrupId=3 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/6",BaslamaTarihi=System.DateTime.Today, CihazId =9, KonumId=9,MonitorId =9,GrupId=3 },

            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/10",BaslamaTarihi=System.DateTime.Today, CihazId =10, KonumId=10,MonitorId =10,GrupId=2 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/11",BaslamaTarihi=System.DateTime.Today, CihazId =11, KonumId=11,MonitorId =11,GrupId=2 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/12",BaslamaTarihi=System.DateTime.Today, CihazId =12, KonumId=12,MonitorId =12,GrupId=2 },

            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/13",BaslamaTarihi=System.DateTime.Today, CihazId =13, KonumId=13,MonitorId =13,GrupId=1 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/14",BaslamaTarihi=System.DateTime.Today, CihazId =14, KonumId=14,MonitorId =14,GrupId=1 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/15",BaslamaTarihi=System.DateTime.Today, CihazId =15, KonumId=15,MonitorId =15,GrupId=1 },
            new Ekran(){ Aciklama = "", AktifMi = true, EkranUrl="http://nobetcieczanesistemi.com/onee/16",BaslamaTarihi=System.DateTime.Today, CihazId =16, KonumId=16,MonitorId =16,GrupId=1 },


            };

            context.Ekranlar.AddOrUpdate(s => new { s.Id }, Ekranlar.ToArray());
            context.SaveChanges();
            #endregion

            #region ekranTasarimIcerikler
            var EkranTasarimIcerikler = new List<EkranTasarimIcerik>()
                            {
            new EkranTasarimIcerik() {EkranIcerikId = 1, EkranTasarimId =1, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 2, EkranTasarimId =1, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 3, EkranTasarimId =2, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 4, EkranTasarimId =2, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},

            new EkranTasarimIcerik() {EkranIcerikId = 5, EkranTasarimId =3, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 6, EkranTasarimId =3, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 7, EkranTasarimId =4, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 8, EkranTasarimId =4, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},

            new EkranTasarimIcerik() {EkranIcerikId = 9, EkranTasarimId =5, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 10, EkranTasarimId =5, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 11, EkranTasarimId =6, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 12, EkranTasarimId =6, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},

            new EkranTasarimIcerik() {EkranIcerikId = 13, EkranTasarimId =7, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 14, EkranTasarimId =7, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 15, EkranTasarimId =8, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            new EkranTasarimIcerik() {EkranIcerikId = 16, EkranTasarimId =8, KoordinatX=1, KoordinatY=1, BoyutX=40, BoyutY=30},
            };

            context.EkranTasarimIcerikler.AddOrUpdate(s => new { s.Id }, EkranTasarimIcerikler.ToArray());
            context.SaveChanges();
            #endregion

            #region yayýn ekran
            var yayinEkran = new List<YayinEkran>()
                            {
                                new YayinEkran(){ EkranId=1, EkranTasarimId=1, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=2, EkranTasarimId=2, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=3, EkranTasarimId=2, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },

                                new YayinEkran(){ EkranId=4, EkranTasarimId=3, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=5, EkranTasarimId=3, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=6, EkranTasarimId=4, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },

                                new YayinEkran(){ EkranId=7, EkranTasarimId=5, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=8, EkranTasarimId=5, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=9, EkranTasarimId=6, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },

                                new YayinEkran(){ EkranId=10, EkranTasarimId=7, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=11, EkranTasarimId=7, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=12, EkranTasarimId=8, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },

                                new YayinEkran(){ EkranId=13, EkranTasarimId=10, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=14, EkranTasarimId=10, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },
                                new YayinEkran(){ EkranId=15, EkranTasarimId=11, BaslamaZamani=DateTime.Now, BitisZamani=DateTime.Now.AddDays(10) },

                            };

            context.YayinEkranlar.AddOrUpdate(s => new { s.EkranId, s.EkranTasarimId }, yayinEkran.ToArray());
            context.SaveChanges();
            #endregion
        }
    }
}
