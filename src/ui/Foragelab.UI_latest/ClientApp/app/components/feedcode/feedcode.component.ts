import { Component, OnInit } from '@angular/core';
import { FeedCodeService } from "../../core/services/feedcode.service";
import { FeedCodeModel, feedcodeFullDataTableConfig } from "../../shared/models/feedcode";
import { DataTableConfig } from "../../shared/models/data-table-config";

@Component({   
    templateUrl: './feedcode.component.html'
})
export class FeedcodeComponent implements OnInit {
    feedcodes: Array<FeedCodeModel>; 
    searchFor: string = '';
    constructor(private FeedcodeService: FeedCodeService) {
        
    }
    FeedcodeConfig: DataTableConfig = feedcodeFullDataTableConfig; 

    ngOnInit() {

        this.FeedcodeConfig.filter = () => {
            if (this.searchFor.length == 0) {
                return null;
            }
            return 'name ctn ' + this.searchFor; // + ' or ' +
            //'alias ctn ' + this.searchFor + ' or ' +
            //'phoneNumber ctn ' + this.searchFor + ' or ' +
            //'website ctn ' + this.searchFor + ' or ' +
            //'faxNumber ctn ' + this.searchFor;
        };
        this.loadFeedCodes(); 
    }

    loadFeedCodes() {
        this.FeedcodeService.getFeedcode().subscribe(
            FeedCodes => {
                this.feedcodes = FeedCodes.json();       
            }
        )
    }

}

