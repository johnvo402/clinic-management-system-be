using AutoFixture;
using CMS_BE.Application.Features.Humans.Common.Projections.Patients;
using CMS_BE.Domain.Aggregates.Humans.Enums;
using FluentValidation;
using FluentValidation.TestHelper;

namespace UnitTesting.Humans
{
    public class CreatePatientCommandValidatorTests
    {
        private readonly InlineValidator<PatientModel> validator;
        private readonly Fixture fixture;
        private readonly PatientModel patient;

        public CreatePatientCommandValidatorTests()
        {
            validator = new InlineValidator<PatientModel>();
            fixture = new Fixture();

            // Tạo patient với dữ liệu hợp lệ mặc định
            patient = fixture
                .Build<PatientModel>()
                .With(x => x.FullName, "Thanh Thư")
                .With(x => x.Age, 18)
                .With(x => x.Gender, Gender.Male)
                .With(x => x.Note, "Ghi chú")
                .Create();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Validate_WhenFullNameNullOrEmpty_ShouldReturnNotEmptyMessage(
            string? fullName
        )
        {
            // Arrange
            patient.FullName = fullName;
            validator
                .RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Tên không được để trống.");

            // Act
            var result = await validator.TestValidateAsync(patient);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.FullName)
                .WithErrorMessage("Tên không được để trống.");
        }

        [Fact]
        public async Task Validate_WhenFullNameExceedsMaxLength_ShouldReturnMaximumLengthMessage()
        {
            // Arrange
            patient.FullName = new string('A', 101);
            validator
                .RuleFor(x => x.FullName)
                .MaximumLength(100)
                .WithMessage("Tên không được vượt quá 100 ký tự.");

            // Act
            var result = await validator.TestValidateAsync(patient);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.FullName)
                .WithErrorMessage("Tên không được vượt quá 100 ký tự.");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(121)]
        public async Task Validate_WhenAgeOutOfRange_ShouldReturnInclusiveBetweenMessage(int age)
        {
            // Arrange
            patient.Age = age;
            validator
                .RuleFor(x => x.Age)
                .InclusiveBetween(0, 120)
                .WithMessage("Age must be between 0 and 120.");

            // Act
            var result = await validator.TestValidateAsync(patient);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Age)
                .WithErrorMessage("Age must be between 0 and 120.");
        }

        [Fact]
        public async Task Validate_WhenGenderInvalid_ShouldReturnIsInEnumMessage()
        {
            // Arrange
            patient.Gender = (Gender)999;
            validator.RuleFor(x => x.Gender).IsInEnum().WithMessage("Giới tính không hợp lệ.");

            // Act
            var result = await validator.TestValidateAsync(patient);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Gender)
                .WithErrorMessage("Giới tính không hợp lệ.");
        }

        [Fact]
        public async Task Validate_WhenNoteExceedsMaxLength_ShouldReturnMaximumLengthMessage()
        {
            // Arrange
            patient.Note = new string('B', 501);
            validator
                .RuleFor(x => x.Note)
                .MaximumLength(500)
                .WithMessage("Ghi chú không được vượt quá 500 ký tự.");

            // Act
            var result = await validator.TestValidateAsync(patient);

            // Assert
            result
                .ShouldHaveValidationErrorFor(x => x.Note)
                .WithErrorMessage("Ghi chú không được vượt quá 500 ký tự.");
        }
    }
}
