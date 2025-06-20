using DrugPrevention.Repositories.DuyenCTT.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.DuyenCTT
{
    public interface IUnitOfWork : IDisposable
    {
        SystemUserAccountRepository SystemUserAccountRepository { get; }

        CourseDuyenCTTRepository CourseDuyenCTTRepository { get; }

        CourseEnrollmentDuyenCTTRepository CourseEnrollmentDuyenCTTRepository { get; }

        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SE18_PRN232_SE1731_G2_MaToeContext _context;
        private SystemUserAccountRepository _systemUserAccountRepository;
        private CourseDuyenCTTRepository _courseDuyenCTTRepository;
        private CourseEnrollmentDuyenCTTRepository _courseEnrollmentDuyenCTTRepository;
        public UnitOfWork() => _context ??= new SE18_PRN232_SE1731_G2_MaToeContext();

        public SystemUserAccountRepository SystemUserAccountRepository
        {
            get { return _systemUserAccountRepository ??= new SystemUserAccountRepository(_context); }
        }

        public CourseDuyenCTTRepository CourseDuyenCTTRepository
        {
            get { return _courseDuyenCTTRepository ??= new CourseDuyenCTTRepository(_context); }
        }

        public CourseEnrollmentDuyenCTTRepository CourseEnrollmentDuyenCTTRepository
        {
            get { return _courseEnrollmentDuyenCTTRepository ??= new CourseEnrollmentDuyenCTTRepository(_context); }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
