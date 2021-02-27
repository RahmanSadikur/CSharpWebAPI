using NMS.Core.Object;
using NMS.Entities;
using NMS.Repo.Testing;
using NMS.RepoImp.Bases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMS.RepoImp.Testing
{
    public class TestRepo : BaseRepo, ITestRepo
    {
        public ListResult<Test> Get()
        {
            var result = new ListResult<Test>();

            var query = from c in ContextHandler.Tests.AsNoTracking()
                        select c;

            result.Count = query.Count();
            result.Data = query.ToList();
            return result;
        }

        public ListResult<Test> Get(string searchKey)
        {
            var result = new ListResult<Test>();

            IQueryable<Test> query = from c in ContextHandler.Tests.AsNoTracking()
                                     select c;

            if (!string.IsNullOrEmpty(searchKey)
                && !string.IsNullOrWhiteSpace(searchKey))
            {
                query = from c in query
                        where SqlFunctions.StringConvert((double)c.ID).Contains(searchKey)
                              || c.Name.Contains(searchKey)
                        select c;
            }

            result.Count = query.Count();

            result.Data = query.ToList();
            return result;
        }

        public Result<Test> Save(Test test)
        {
            var context = ContextHandler;
            var result = new Result<Test>();

            using (DbContextTransaction scope = context.Database.BeginTransaction())
            {
                try
                {
                    bool isNewObject = false;
                    Test objToSave = context.Tests.SingleOrDefault(um => um.ID == test.ID);

                    if (objToSave == null)
                    {
                        isNewObject = true;
                        objToSave = new Test();
                        context.Tests.Add(objToSave);
                    }


                    CopyObject<Test>(ref test, ref objToSave);

                    if (!IsValidToSave(isNewObject, objToSave, result))
                        return result;

                    context.SaveChanges();
                    scope.Commit();

                    result.Data = objToSave;
                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    SetError(ex, result);
                }
                finally
                {
                    ContextHandler.Dispose();
                }

                return result;
            }
        }

        public Result<bool> Delete(int id)
        {
            var result = new Result<bool>();
            using (var scope = ContextHandler.Database.BeginTransaction())
            {


                var obj = ContextHandler.Tests.SingleOrDefault(cb => cb.ID == id);
                if (obj == null)
                {
                    result.Messages.Add("Testing1DoesNotExists.");
                    result.HasError = true;
                    return result;
                }


                try
                {
                    ContextHandler.Tests.Remove(obj);
                    ContextHandler.SaveChanges();
                    scope.Commit();
                    result.Data = true;
                }
                catch (Exception ex)
                {
                    scope.Rollback();
                    result.Messages.Add("UnexpectedProblemOccured.");
                    result.HasError = true;
                }
                finally
                {
                    ContextHandler.Dispose();
                }
            }

            return result;
        }




        private bool IsValidToSave(bool isNewObject, Test objToSave, Result<Test> result)
        {
            if (isNewObject && ContextHandler.Tests.AsNoTracking().Any(cb => cb.Name == objToSave.Name))
            {
                result.Messages.Add("TestNameExists.");
                result.HasError = true;
                return false;
            }

            if (!isNewObject && ContextHandler.Tests.AsNoTracking().Any(cb => cb.Name == objToSave.Name && cb.ID != objToSave.ID))
            {
                result.Messages.Add("Testing1Exists.");
                result.HasError = true;
                return false;
            }

            return true;
        }

    }
}
