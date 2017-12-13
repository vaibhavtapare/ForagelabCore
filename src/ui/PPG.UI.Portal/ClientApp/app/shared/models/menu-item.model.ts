
export class MenuItem {
    text?: string;
    link?: string;
    
    initials?: string;
    icon?: string;
    iconBgClass: string;
    
    pageTitle?: string;
    alert?: string;

    requiredPrivileges: Array<string>;

    submenu?: Array<MenuItem>;

    routeIsActive: boolean;
    isExpanded: boolean;
}