using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Dndp.Persistence.Entity.OffLineReport;
using Dndp.Persistence.Entity.Security;
using Dndp.Utility.CSV;
//TODO: Add other using statements here.

namespace Dndp.Service.OffLineReport
{
    public interface IReportJobMgr
    {
        #region Method Created By CodeSmith

        void CreateReportJob(ReportJob entity);

        ReportJob LoadReportJob(int id);

        void UpdateReportJob(ReportJob entity);

        void DeleteReportJob(int id);

        void DeleteReportJob(ReportJob entity);

        void DeleteReportJob(IList<int> idList);

        void DeleteReportJob(IList<ReportJob> entityList);

	    void CreateReportJobUser(ReportJobUser entity);

        ReportJobUser LoadReportJobUser(int id);

        void UpdateReportJobUser(IList<int> idList, int jobId);

        void DeleteReportJobUser(int id);

        void DeleteReportJobUser(ReportJobUser entity);

        void DeleteReportJobUser(IList<int> idList);

        void DeleteReportJobUser(IList<ReportJobUser> entityList);

	    void CreateReportJobReport(ReportJobReport entity);

        ReportJobReport LoadReportJobReport(int id);

        void UpdateReportJobReport(IList<int> idList, int jobId);

        void DeleteReportJobReport(int id);

        void DeleteReportJobReport(ReportJobReport entity);

        void DeleteReportJobReport(IList<int> idList);

        void DeleteReportJobReport(IList<ReportJobReport> entityList);

        #endregion Method Created By CodeSmith

        #region Customized Methods

        //TODO: Add other methods here.
        IList<ReportBatch> FindReportBatchWithJob(User user);

        IList FindReportJobByBatchId(int Id);

        IList FindReportByJobId(int Id);

        IList FindUserByJobId(int Id);

        void CancelReportJob(ReportJob job, User user);

        void RestartReportJob(ReportJob job, User user);

        void CancelReportJob(int jobId, User user);

        void RestartReportJob(int jobId, User user);

        void SubmitReportJob(int jobId, User user);

        ReportJob CreateNewReportJobByBatchId(int id, User user);

        IList<ReportUser> FindReportUserByReportBatchIdAndUserNameAndUserDescription(int batchId, string userName, string userDescription);

        ReportJobValidationResult LoadReportJobValidationResult(int id);

        void DownloadValidateResult(string rule, CSVWriter csvWriter, int jobId);

        IList FindValidationResultByIds(string validationIds);

        ReportJobValidationResult ValidateRule(int id, User actionUser);

        #endregion Customized Methods

    }
}
