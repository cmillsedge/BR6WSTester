using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace BRWS6
{
    class BRCatalogTester
    {
        private Session _session;
        private string _url;
        public BRCatalogTester(Session session, string url)
        {
            _session = session;
            _url = url;
        }

        public TestOutcome GetDataFormats()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "DataFormats";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                DataFormatArray formats = catalogueApi.DataFormats(_session.SessionId);
                foreach (DataFormat format in formats)
                {
                    Console.WriteLine(format.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetElementTypes()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "CatalogueElementTypes";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                ElementTypeArray elementTypes = catalogueApi.CatalogueElementTypes(_session.SessionId);
                foreach (ElementType elementType in elementTypes)
                {
                    Console.WriteLine(elementType.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetStates()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "CatalogueStates";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                NamedArray states = catalogueApi.CatalogueStates(_session.SessionId);
                foreach (Named state in states)
                {
                    Console.WriteLine(state.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetTeams()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "CatalogueTeams";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                NamedArray teams = catalogueApi.CatalogueTeams(_session.SessionId);
                foreach (Named team in teams)
                {
                    Console.WriteLine(team.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetMemberships()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "CatalogueMemberships";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                NamedArray members = catalogueApi.CatalogueMemberships(_session.SessionId, "user", null);
                foreach (Named member in members)
                {
                    Console.WriteLine(member.Id);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetParameterTypes()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "CatalogueParameterTypes";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                ParameterTypeArray parameterTypes = catalogueApi.CatalogueParameterTypes(_session.SessionId);
                foreach (ParameterType parameterType in parameterTypes)
                {
                    Console.WriteLine(parameterType.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetConcepts()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "DataConcepts";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                NamedArray dataConcepts = catalogueApi.DataConcepts(_session.SessionId);
                foreach (Named dataConcept in dataConcepts)
                {
                    Console.WriteLine(dataConcept.Path);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetParamAliases()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "CatalogueParameters";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                ParameterTypeAliasArray parameterTypeAliases = catalogueApi.CatalogueParameters(_session.SessionId);
                foreach (ParameterTypeAlias parameterTypeAlias in parameterTypeAliases)
                {
                    Console.WriteLine(parameterTypeAlias.Path);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetLookups()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "DataElements";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                NamedArray dataElements = catalogueApi.DataElements(_session.SessionId);
                foreach (Named dataElement in dataElements)
                {
                    Console.WriteLine(dataElement.Path + dataElement.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }

        public TestOutcome GetLookupValues()
        {
            TestOutcome outcome = new TestOutcome();
            outcome.moduleName = "Catalog";
            outcome.methodName = "DataValues";
            try
            {
                CatalogueApi catalogueApi = new CatalogueApi(_url);
                NamedArray dataElements = catalogueApi.DataValues(_session.SessionId, "/Root/Internal/User/User", "", 100, 0);
                foreach (Named dataElement in dataElements)
                {
                    Console.WriteLine(dataElement.Name);
                }
                outcome.outcome = "Success";
                return outcome;
            }
            catch (Exception ex)
            {
                outcome.outcome = ex.Message;
                return outcome;
            }
        }


        public List<TestOutcome> TestAll()
        {
            List<TestOutcome> outcomes = new List<TestOutcome>();

            SessionOperations.RefreshSession(_url, _session.SessionId);
            //run all methods
            TestOutcome dataFormats = GetDataFormats();
            outcomes.Add(dataFormats);
            TestOutcome elementTypes = GetElementTypes();
            outcomes.Add(elementTypes);
            TestOutcome states = GetStates();
            outcomes.Add(states);
            TestOutcome teams = GetTeams();
            outcomes.Add(teams);
            TestOutcome members = GetMemberships();
            outcomes.Add(members);
            TestOutcome paramTypes = GetParameterTypes();
            outcomes.Add(paramTypes);
            TestOutcome concepts = GetConcepts();
            outcomes.Add(concepts);
            TestOutcome lookups = GetLookups();
            outcomes.Add(lookups);
            TestOutcome paramAliases = GetParamAliases();
            outcomes.Add(paramAliases);
            TestOutcome values = GetLookupValues();
            outcomes.Add(values);
            SessionOperations.RefreshSession(_url, _session.SessionId);

            //return all the outcomes
            return outcomes;
        }
    }       
}

