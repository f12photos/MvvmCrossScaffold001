using System;
using SQLite;

namespace MvvmCrossScaffold001.Core.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
