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
    
    public partial class ModelTV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModelTV()
        {
            this.TransportVehicle = new HashSet<TransportVehicle>();
        }
    
        public int IdModelTV { get; set; }
        public int IdBrandTV { get; set; }
        public string NameModel { get; set; }
    
        public virtual BrandTV BrandTV { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransportVehicle> TransportVehicle { get; set; }
    }
}
