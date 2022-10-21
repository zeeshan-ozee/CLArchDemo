using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Domain;
using FluentAssertions;
using NetArchTest.Rules;

namespace CL.ArchitectureTest
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "CLArch.Domain";
        private const string ApplicationNamespace = "CLArch.Application";
        private const string InfrastructureNamespace = "CLArch.Infrastructure";
        private const string PersistanceNamespace = "CLArch.Persistance";
        private const string PresentationNamespace = "CLArch.WebApi";

        [Fact]
        public void Domain_Should_not_have_dependency_on_otherProject()
        {

            //arrange
            var domainAssembly = typeof(CLArch.Domain.AssemblyDiscovery).Assembly;

            var otherProjects = new[] {
                    ApplicationNamespace,InfrastructureNamespace,PersistanceNamespace,PresentationNamespace
            };
            //act
            var testResults = Types
                .InAssembly(domainAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            testResults.IsSuccessful.Should().BeTrue();


        }

        [Fact]
        public void Application_Should_not_have_dependency_on_otherProject()
        {

            //arrange
            var appAssembly = typeof(CLArch.Application.DependencyInjector).Assembly;

            var otherProjects = new[] {
                    InfrastructureNamespace,PersistanceNamespace,PresentationNamespace
            };
            //act
            var testResults = Types
                .InAssembly(appAssembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //assert
            testResults.IsSuccessful.Should().BeTrue();


        }


        [Fact]
        public void Handlers_should_have_dependency_onDomain()
        {
            //arrange
            var appAssembly = typeof(CLArch.Application.DependencyInjector).Assembly;


            //act
            var testResults = Types
                .InAssembly(appAssembly)
                .That()
                .HaveNameEndingWith("Handler")
                .Should()
                .HaveDependencyOn(DomainNamespace)
                .GetResult();

            //assert
            testResults.IsSuccessful.Should().BeTrue();
        }


        [Fact]
        public void Entities_should_inherit_baseEntity()
        {
            //arrange
            var appAssembly = typeof(CLArch.Domain.AssemblyDiscovery).Assembly;


            //act 

            var testResults = Types
           .InAssembly(appAssembly)
           .That()
           .ResideInNamespace("CLArch.Domain.Entities")
           .Should()
           .Inherit(typeof(CLArch.Domain.Common.BaseEntity<>).GetType())
           .GetResult();

            //assert
            testResults.IsSuccessful.Should().BeTrue();
        }


    }
}