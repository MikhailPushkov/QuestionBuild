//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuestBuild
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fakultet
    {
        public Fakultet()
        {
            this.Kafedra = new HashSet<Kafedra>();
        }
    
        public int ID_Faculteta { get; set; }
        public string Nazvanie_Fakulteta { get; set; }
    
        public virtual ICollection<Kafedra> Kafedra { get; set; }
    }
}
