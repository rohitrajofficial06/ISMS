using AutoMapper;
using ISMSPortal.Models;

using ISMSPortal.ViewModels.Announcement;
using ISMSPortal.ViewModels.Awareness;
using ISMSPortal.ViewModels.Dashboard;
using ISMSPortal.ViewModels.Document;
using ISMSPortal.ViewModels.Policy;
using ISMSPortal.ViewModels.SecurityAlert;

namespace ISMSPortal.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Announcement
            CreateMap<Announcement, AnnouncementCreateViewModel>().ReverseMap();
            CreateMap<Announcement, AnnouncementEditViewModel>().ReverseMap();
            CreateMap<Announcement, AnnouncementListViewModel>();
            CreateMap<Announcement, AnnouncementWidgetViewModel>();

            // Policy

            CreateMap<Policy, PolicyCreateViewModel>().ReverseMap();
            CreateMap<Policy, PolicyEditViewModel>().ReverseMap();
            CreateMap<Policy, PolicyListViewModel>();
            // Document Mapping
            CreateMap<Models.Document, DocumentCreateViewModel>().ReverseMap();
            CreateMap<Models.Document, DocumentEditViewModel>().ReverseMap();
            CreateMap<Models.Document, DocumentListViewModel>();
            CreateMap<Models.Document, DocumentWidgetViewModel>();

            // Security Alert
            CreateMap<SecurityAlert, SecurityAlertCreateViewModel>().ReverseMap();
            CreateMap<SecurityAlert, SecurityAlertEditViewModel>().ReverseMap();
            CreateMap<SecurityAlert, SecurityAlertListViewModel>();

            // Awareness Session
            CreateMap<AwarenessSession, AwarenessSessionCreateViewModel>().ReverseMap();
            CreateMap<AwarenessSession, AwarenessSessionEditViewModel>().ReverseMap();
            CreateMap<AwarenessSession, AwarenessSessionListViewModel>();
            CreateMap<AwarenessSession, AwarenessSessionWidgetViewModel>();

            // Awareness Progress
            CreateMap<AwarenessProgress, AwarenessProgressViewModel>().ReverseMap();

        }
    }
}