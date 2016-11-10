namespace TrialExam2Tutor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SensorData")]
    public partial class SensorData
    {
        public Guid Id { get; set; }

        public byte Light { get; set; }

        public byte Temperature { get; set; }

        [Required]
        [StringLength(20)]
        public string TimeStamp { get; set; }
    }
}
