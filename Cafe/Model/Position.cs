//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cafe.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Position
    {
        public Position()
        {
            this.OrderPosition = new HashSet<OrderPosition>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int PositionTypeId { get; set; }
        public string Photo { get; set; }
    
        public virtual ICollection<OrderPosition> OrderPosition { get; set; }
        public virtual PositionType PositionType { get; set; }
    }
}