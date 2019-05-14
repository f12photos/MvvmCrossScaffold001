using System;
using SQLite;

namespace MvvmCrossScaffold001.Core.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
        }

        [PrimaryKey]
        public int Id { get; set; }
    }
}
