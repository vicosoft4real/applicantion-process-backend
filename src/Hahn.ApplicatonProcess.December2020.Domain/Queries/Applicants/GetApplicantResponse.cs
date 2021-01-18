using Hahn.ApplicatonProcess.December2020.Data.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Interface;

namespace Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants
{
    /// <summary>
    /// Applicant Response
    /// </summary>
    public class GetApplicantResponse : IMapFrom<Applicant>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the family for the applicant.
        /// </summary>
        /// <value>
        /// The name of the family.
        /// </value>

        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the address of the applicant.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the country of origin for the applicant.
        /// </summary>
        /// <value>
        /// The country of origin.
        /// </value>
        public string CountryOfOrigin { get; set; }
        /// <summary>
        /// Gets or sets the email address for the applicant.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the age of the applicant.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GetApplicantResponse"/> is hired.
        /// </summary>
        /// <value>
        ///   <c>true</c> if hired; otherwise, <c>false</c>.
        /// </value>
        public bool Hired { get; set; }
    }
}
