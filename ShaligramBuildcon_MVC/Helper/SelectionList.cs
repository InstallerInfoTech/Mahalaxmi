using Data.ShaligramBuildcon_MVC.DB;
using Data.ShaligramBuildcon_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShaligramBuildcon_MVC.Helper
{
    public class SelectionList
    {
        public static List<ProjectType> ProjectTypeList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.ProjectType.Where(m => m.IsActive).OrderBy(x => x.TypeId).ToList();
            }
        }

        public static List<ProjectStatus> ProjectStatusList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.ProjectStatus.Where(m => m.IsActive).OrderBy(x => x.StatusId).ToList();
            }
        }

        public static List<Roles> RoleList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.Roles.OrderBy(x => x.RoleId).ToList();
            }
        }
        public static List<PaymentPlanMaster> PaymentPlanMasterList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                //return _dbContext.PaymentPlanMaster.OrderBy(x => x.PaymentPlanMasterId).ToList();
                var list = new object();
                if (SessionHelper.IsSuperAdmin)
                {
                    list = _dbContext.PaymentPlanMaster.OrderBy(x => x.PaymentPlanMasterId).ToList();

                }
                else
                {
                    list = _dbContext.PaymentPlanMaster.Where(x=>x.IsCommercial).OrderBy(x => x.PaymentPlanMasterId).ToList();
                }
                return (List<PaymentPlanMaster>)list;
            }

            
        }

        public static List<States> StatesList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.States.Where(m => m.IsActive).OrderBy(x => x.StateId).ToList();
            }
        }
        public static List<Project> ProjectList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                List<int> accessList = _dbContext.ProjectAccess.Where(k => k.EmployeeId == SessionHelper.EmployeeId).Select(x => x.ProjectId).ToList();
                var list = !SessionHelper.IsSuperAdmin ? 
                                _dbContext.Project.Where(m => (accessList.Contains(m.ProjectId)) && (m.IsActive)).OrderBy(x => x.ProjectId).ToList() :
                                _dbContext.Project.Where(m => accessList.Contains(m.ProjectId)).OrderBy(x => x.ProjectId).ToList();
                return list;
            }
        }
        public static List<Employees> AttendeeList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.Employees.Where(m => m.IsActive && !m.IsSuperAdmin).OrderBy(x => x.EmployeeId).ToList();
            }
        }
        public static List<Employees> DeactivateAttendeeList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.Employees.Where(m => !m.IsActive && !m.IsSuperAdmin).OrderBy(x => x.EmployeeId).ToList();
            }
        }
        public static List<Status> StatusList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.Status.OrderBy(x => x.StatusId).ToList();
            }
        }

        public static List<PropertyType> PropertyTypeList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.PropertyType.OrderBy(x => x.TypeId).ToList();
            }
        }

        public static List<SACCodeMaster> SACCodeList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.SACCodeMaster.OrderBy(x => x.CodeId).ToList();
            }
        }
        
        public static List<Members> MemberList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.Members.OrderBy(x => x.MemberId).ToList();
            }
        }

        public static List<ProjectUnitBlocks> UnitBlockList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.ProjectUnitBlocks.OrderBy(x => x.ProjectUnitId).ToList();
            }
        }

        public static List<ProjectPlan> ProjectPlanList(int? ProjectId = null)
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.ProjectPlan.Where(m=>m.ProjectId == ProjectId || ProjectId == null).OrderBy(x => x.ProjectPlanId).ToList();
            }
        }

        public static List<ProjectPlan> GetProjectPlanList(int ProjectId)
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.ProjectPlan.Where(m => m.ProjectId == ProjectId).OrderBy(x => x.ProjectPlanId).ToList();
            }
        }

        public static List<ResponseType> ResponseTypeList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.ResponseType.OrderBy(x => x.ResponseTypeId).ToList();
            }
        }
        public static List<CommunicationModes> CommunicationModeList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.CommunicationModes.OrderBy(x => x.ModeId).ToList();
            }
        }

        public static List<PaymentPlan> PaymentPlanList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.PaymentPlan.OrderBy(x => x.PlanId).ToList();
            }
        }

        public static List<PaymentTransferMode> PaymentTransferList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.PaymentTransferMode.OrderBy(x => x.PaymentTransferModeId).ToList();
            }
        }

        public static List<BankMaster> BankMasterList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                return _dbContext.BankMaster.OrderBy(x => x.BankName).ToList();
            }
        }
        public static List<Units> UnitList()
        {
            using (BuildconPMSMVCEntities _dbContext = BaseContext.GetDbContext())
            {
                var list= _dbContext.Units.OrderBy(x => x.Name).ToList();
                return list;
            }
        }
    }
}