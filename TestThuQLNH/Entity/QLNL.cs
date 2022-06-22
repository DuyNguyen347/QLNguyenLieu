using System;
using System.Data.Entity;
using System.Linq;

namespace TestThuQLNH
{
    public class QLNL : DbContext
    {
        private static QLNL instance;
        // Your context has been configured to use a 'QLNH' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TestThuQLNH.QLNH' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLNH' 
        // connection string in the application configuration file.
        public QLNL()
            : base("name=QLNH")
        {
            Database.SetInitializer<QLNL>(new CreateDB());
        }
        public static QLNL Instance
        {
            get
            {
                if (instance == null)
                    instance = new QLNL();
                return instance;
            }
            set => instance = value;
        }
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; }

        public virtual DbSet<MonAn> MonAns { get; set; }

        public virtual DbSet<MonAnNguyenLieu> MonAnNguyenLieus { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}