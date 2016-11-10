namespace TrialExam2Tutor
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SensorModel : DbContext
    {
        public SensorModel()
            : base("name=SensorModel")
        {
        }

        public virtual DbSet<SensorData> SensorDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
