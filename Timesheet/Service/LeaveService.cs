using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheet.Interfaces;
using Timesheet.Models;
using Timesheet.Models.DTO;
using Timesheet.Enum;

namespace Timesheet.Service
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHRRepository _HRRepository;

        public LeaveService(ILeaveRepository leaveRepository, IEmployeeRepository employeeRepository, IHRRepository HRRepository)
        {
            _leaveRepository = leaveRepository;
            _employeeRepository = employeeRepository;
            _HRRepository = HRRepository;
        }

        // Employee submits a leave request
        public async Task<LeaveResponseDto> SubmitLeaveRequest(SubmitLeaveDto dto, int userId)
        {
            var employee = await _employeeRepository.GetByUserId(userId);
            if (employee == null)
                throw new Exception("Employee not found");

            // Validation: Employees cannot apply for past dates
            if (dto.StartDate < DateOnly.FromDateTime(DateTime.UtcNow))
                throw new Exception("Leave request cannot be for past dates.");


            var leaveRequest = new LeaveDb
            {
                EmployeeId = employee.Id,
                EmployeeName = employee.FullName,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                Status = LeaveStatus.Pending
            };

            var savedLeave = await _leaveRepository.SubmitLeaveRequest(leaveRequest);
            return new LeaveResponseDto
            {
                Id = savedLeave.Id,
                EmployeeName = savedLeave.EmployeeName,
                StartDate = savedLeave.StartDate,
                EndDate = savedLeave.EndDate,
                Status = savedLeave.Status.ToString()
            };
        }

        // Approve/Reject Leave Request
        public async Task<string> ApproveLeave(int approverId, ApproveLeaveDto dto)
        {
            var leaveRequest = await _leaveRepository.GetLeaveById(dto.LeaveId);
            if (leaveRequest == null)
                throw new Exception("Leave request not found");

            var employeeApprover = await _employeeRepository.GetByUserId(approverId);
            var hrApprover = await _HRRepository.GetByUserId(approverId);

            if (employeeApprover == null && hrApprover == null)
                throw new Exception("Approver not found");

            // Manager Approval
            if (employeeApprover?.Designation.Contains("Manager") == true && leaveRequest.Status == LeaveStatus.Pending)
            {
                leaveRequest.Status = LeaveStatus.ManagerApproved;
                await _leaveRepository.UpdateLeaveRequest(leaveRequest);
                return "Leave request has been approved by Manager.";
            }

            // HR Approval (Final Step)
            if (hrApprover != null && hrApprover.User?.Role == "HR" && leaveRequest.Status == LeaveStatus.ManagerApproved)
            {
                leaveRequest.Status = LeaveStatus.Approved;
                await _leaveRepository.UpdateLeaveRequest(leaveRequest);
                return "Leave request has been approved by HR.";
            }

            throw new Exception("You are not authorized to approve this leave request.");
        }

        // Employee views their leave requests (Pending, Approved, Rejected)
        public async Task<List<LeaveResponseDto>> GetEmployeeLeaves(int employeeId)
        {
            // Ensure employeeId is valid
            if (employeeId <= 0)
                throw new ArgumentException("Invalid Employee ID");

            var leaves = await _leaveRepository.GetLeavesByEmployeeId(employeeId);

            // Check if there are no leave requests
            if (leaves == null || leaves.Count == 0)
                return new List<LeaveResponseDto>(); // Return an empty list instead of null

            var leaveDtos = new List<LeaveResponseDto>();

            foreach (var leave in leaves)
            {
                leaveDtos.Add(new LeaveResponseDto
                {
                    Id = leave.Id,
                    EmployeeName = leave.Employee?.FullName ?? "Unknown", // Ensure Employee name exists
                    StartDate = leave.StartDate,
                    EndDate = leave.EndDate,
                    Status = leave.Status.ToString()
                });
            }

            return leaveDtos;
        }
    }
}

