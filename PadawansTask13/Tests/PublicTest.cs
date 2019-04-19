using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using System.Collections.Generic;

namespace PadawansTask13.Tests
{
  [TestFixture]
  public class PublicTest
  {
    private readonly string[] _fields = { "surname", "age" };

    [Test]
    public void Employee_Class_Is_Created()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      Assert.IsNotNull(employeeType, "'Employee' class is not created.");
    }

    [Test]
    public void All_Fields_Are_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();
      var notDefinedFields = new List<string>();

      var employeeFields = this.GetAllNonPublicFields(assemblyContent);
      foreach (var field in _fields)
      {
        var instanceField = employeeFields.FirstOrDefault(f => f.Name.ToLower().Contains(field));
        if (instanceField == null)
        {
          notDefinedFields.Add(field);
        }
      }

      if (notDefinedFields.Count == 0)
      {
        notDefinedFields = null;
      }

      Assert.IsNull(notDefinedFields, $"Fields: {notDefinedFields?.Aggregate((previous, next) => $"'{previous}', {next}")} are not defined.");
    }

    [Test]
    public void Default_Contstructor_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));
      var defaultConstructor = employeeType?.GetConstructor(new Type[] { });

      Assert.IsNotNull(defaultConstructor, "Default contstructor is not defined.");
    }

    [Test]
    public void Parametrized_Constructor_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var constructor = employeeType?.GetConstructors().FirstOrDefault(c =>
      {
        var parameters = c.GetParameters();
        if (parameters.Length > 0 &&
                  parameters.Count(p => p.ParameterType == typeof(string)) == 1 &&
                  parameters.Count(p => p.ParameterType == typeof(int)) == 1)
        {
          return true;
        }

        return false;
      });

      Assert.IsNotNull(constructor, "Parametrized contstructor is not defined.");
    }

    [Test]
    public void Method_With_String_Return_Type_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var method = employeeType?.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
          .FirstOrDefault(m => m.ReturnType == typeof(string) && m.IsPrivate);

      Assert.IsNotNull(method, "Method which should NOT be accessible from outside of the class with" +
                               " string return type is NOT defined.");
    }

    [Test]
    public void Set_Surname_Method_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var method = employeeType?.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
          .FirstOrDefault(m =>
          {
            if (m.ReturnType == typeof(void) && m.GetParameters().All(p => p.ParameterType == typeof(string)))
            {
              return true;
            }

            return false;
          });

      Assert.IsNotNull(method, "Set surname method is not defined");
    }

    [Test]
    public void Get_Employee_Info_Method_Is_Defined()
    {
      var assemblyContent = this.LoadAssemblyContent();

      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      var method = employeeType?.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
          .FirstOrDefault(m =>
          {
            if (m.ReturnType == typeof(string) && m.GetParameters().Length == 0)
            {
              return true;
            }

            return false;
          });

      Assert.IsNotNull(method, "Get employee info method is not defined");
    }

    private Assembly LoadAssemblyContent()
    {
      return Assembly.GetExecutingAssembly();
    }

    private FieldInfo[] GetAllNonPublicFields(Assembly assemblyContent)
    {
      var employeeType = assemblyContent.GetTypes()
          .FirstOrDefault(t => t.Name.Equals("employee", StringComparison.OrdinalIgnoreCase));

      return employeeType?.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
    }
  }
}