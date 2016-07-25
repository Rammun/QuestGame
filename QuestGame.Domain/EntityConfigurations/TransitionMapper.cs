﻿using QuestGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.EntityConfigurations
{
    public class TransitionMapper : EntityTypeConfiguration<Transition>
    {
        public TransitionMapper()
        {
            this.ToTable("Transition");
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Id).IsRequired();
            this.Property(x => x.Description).IsRequired();

            this.HasRequired(x => x.NextFrame)
                .WithRequiredDependent();
        }
    }
}
