//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineExamSystem.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class QuestionXDuration
    {
        public bool Id { get; set; }
        public int RegistrationId { get; set; }
        public int TestQuestionId { get; set; }
        public Nullable<System.DateTime> RequestTime { get; set; }
        public Nullable<System.DateTime> LeaveTime { get; set; }
        public Nullable<System.DateTime> AnsweredTime { get; set; }
    
        public virtual Registiration Registiration { get; set; }
        public virtual TestXQuestion TestXQuestion { get; set; }
    }
}
