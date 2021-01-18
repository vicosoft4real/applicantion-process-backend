using Hahn.ApplicatonProcess.December2020.Data.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Interface;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Update
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{(System.Boolean succeed, System.String message, Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Update.UpdateApplicantCommand update)}" />
    /// <seealso cref="Hahn.ApplicatonProcess.December2020.Domain.Interface.IMapFrom{Hahn.ApplicatonProcess.December2020.Data.Model.Applicant}" />
    public class UpdateApplicantCommand : IRequest<(bool succeed, string message, UpdateApplicantCommand update)>, IMapFrom<Applicant>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the applicant.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <example>Victor</example>

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the family for the applicant.
        /// </summary>
        /// <value>
        /// The name of the family.
        /// </value>
        /// <example>Ogundowo</example>
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the address of the applicant.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        /// <example>77 Community road</example>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the country of origin for the applicant.
        /// </summary>
        /// <value>
        /// The country of origin.
        /// </value>
        /// <example>Nigeria</example>
        public string CountryOfOrigin { get; set; }
        /// <summary>
        /// Gets or sets the email address for the applicant.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        /// <example>vicosoft4real@gmail.com</example>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the age of the applicant.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        /// <example>40</example>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UpdateApplicantCommand"/> is hired.
        /// </summary>
        /// <value>
        ///   <c>true</c> if hired; otherwise, <c>false</c>.
        /// </value>
        public bool Hired { get; set; }
    }
}
