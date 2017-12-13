import { Injectable } from '@angular/core';

/**
 * The setting service stores a users UI settings 
 */
@Injectable()
export class SettingService {
    constructor() {
        this.layout = {
            isCollapsed: false,
            isPinned: true
        };
    }

    /**
     * Object to store layout settings
     */
    public layout: any;

    /**
     * Gets a setting based on the provided name
     * @param {string} name Unique name of the setting to retrieve
     */
    getSetting(name: string) {
        return name ? this.layout[name] : this.layout;
    }

    /**
     * Saves a setting based on the provided name
     * @param {string} name Unique name of the setting to retrieve
     * @param {any} value Value of the setting
     */
    setSetting(name: string, value: any) {
        if (typeof this.layout[name] !== 'undefined') {
            return this.layout[name] = value;
        }
    }

    /**
     * Toggles the setting (Only usable on boolean settings)
     * @param {string} name Unique name of the setting to toggle
     */
    toggleSetting(name) {
        return this.setSetting(name, !this.getSetting(name));
    }
}