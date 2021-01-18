using Hahn.ApplicatonProcess.December2020.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.ApplicatonProcess.December2020.Data.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Hahn.ApplicatonProcess.December2020.Data.Model.Applicant}" />
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        /// <summary>
        /// Configures the entity of type <seealso cref="Applicant"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Address).HasMaxLength(200);
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.CountryOfOrigin).HasMaxLength(200);
            builder.Property(x => x.EmailAddress).IsRequired();
            builder.Property(x => x.FamilyName).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Hired);


        }
    }
}
