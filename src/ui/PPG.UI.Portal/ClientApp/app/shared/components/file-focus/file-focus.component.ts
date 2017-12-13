import { Component, HostBinding, Input, forwardRef } from '@angular/core';
import { AbstractControl, ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl } from '@angular/forms';

const noop = () => {
};

@Component({
    selector: 'file-focus',
    templateUrl: './file-focus.component.html',
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => FileFocusComponent),
            multi: true,
        }     
    ]
})
export class FileFocusComponent implements ControlValueAccessor  {
    
    private string: string;
    private parseError: boolean;
    private hasValue: boolean;
    private innerValue: any = '';

    @HostBinding('class.focused') isFocused: boolean = false;

    @Input() label: string;
    @Input() placeholder: string = '';
    @Input() propertyName: string = '';

    //get accessor
    get value(): any {
        return this.innerValue;
    };

    //set accessor including call the onchange callback
    set value(v: any) {
        if (v !== this.innerValue) {
            this.innerValue = (v && v.length > 0) ? v : '';
            this.onChangeCallback(this.innerValue);
        }
        this.checkValue();
    }

    private onTouchedCallback: () => void = noop;
    private onChangeCallback: (_: any) => void = noop;
  
    writeValue(value: any) {
        if (value !== this.innerValue) {
            this.innerValue = (value && value.length > 0) ? value : '';
        }
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
        if (this.innerValue.length > 0) {
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