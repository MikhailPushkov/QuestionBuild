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
    
    public partial class Otvet
    {
        public int ID_Otveta { get; set; }
        public string Tekst_otveta { get; set; }
        public Nullable<bool> Pravilnost { get; set; }
        public Nullable<int> ID_Voprosa { get; set; }
    
        public virtual Vopros Vopros { get; set; }
    }
}
