//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIPS_GIBDD.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public int IdPerson { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdPosition { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public string PhotoPath { get; set; }
    
        public virtual Position Position { get; set; }
        public virtual User User { get; set; }
    }
}
