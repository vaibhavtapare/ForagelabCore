import { Component, ElementRef, forwardRef, HostBinding, Input, ViewChild } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl, Validator } from '@angular/forms';
import * as _ from 'lodash';

const noop = () => {
};

@Component({
    selector: 'select-focus',
    templateUrl: './select-focus.component.html',
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => SelectFocusComponent),
            multi: true,
        }      
    ]
})
export class SelectFocusComponent implements ControlValueAccessor {
    private string: string;
    private parseError: boolean;
    private hasValue: boolean;
    private innerValue: any = '';

    @HostBinding('class.focused') isFocused: boolean = false;
    @ViewChild('inputElement') selectElement: ElementRef;

    @Input() label: string;
    @Input() propertyName: string = '';
    @Input() dataTextField: string;
    @Input() dataValueField: string;
    @Input() data: Array<any>;
    @Input() isDisabled: boolean = false;

    //get accessor
    get value(): any {
       return this.innerValue;
    };

    //set accessor including call the onchange callback
    set value(v: any) {
        if (v !== this.innerValue) {
            this.innerValue = (v && v.length > 0) ? v : '';
        }
        this.onChangeCallback(this.innerValue);
        this.checkValue();
    }

    private onTouchedCallback: () => void = noop;
    private onChangeCallback: (_: any) => void = noop;

    writeValue(value: any) {
        if (value !== this.innerValue) {
            this.innerValue = (value && value.toString().length > 0) ? value : '';
        }
        this.selectElement.nativeElement.value = value;
        this.checkValue();
    }

    onFocus() {
        this.setFocus(true);
    }

    onBlur() {
        this.onTouchedCallback();
        this.setFocus(false);
    }

    setFocus(isFocused: boolean) {
        this.isFocused = isFocused;
    }

    checkValue() {
        this.hasValue = false;
        if (this.innerValue.toString().length > 0) {
            this.hasValue = true;
        }
    }

    // registers 'fn' that will be fired when changes are made
    // this is how we emit the changes back to the form
    public registerOnChange(fn: any) {
        this.onChangeCallback = fn;
    }

    //From ControlValueAccessor interface
    registerOnTouched(fn: any) {
        this.onTouchedCallback = fn;
    }
}