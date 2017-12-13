import { Component, HostBinding, Input, Inject, forwardRef, Renderer, ElementRef, ViewChild} from '@angular/core';
import { AbstractControl, ControlValueAccessor, NG_VALUE_ACCESSOR, NG_VALIDATORS, FormControl } from '@angular/forms';

const noop = () => {
};

@Component({
    selector: 'input-focus',
    templateUrl: './input-focus.component.html',
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => InputFocusComponent),
            multi: true,
        }      
    ]
})
export class InputFocusComponent implements ControlValueAccessor  {
    constructor(@Inject(Renderer) private renderer: Renderer) { }
    
    private hasValue: boolean;
    private innerValue: any = '';

    @HostBinding('class.focused') isFocused: boolean = false;
    @ViewChild('inputElement') element: ElementRef;

    @Input() label: string;
    @Input() inputType: string='text';
    @Input() placeholder: string = '';
    @Input() propertyName: string = '';
    @Input() disabled: boolean = false;
    @Input() mask: string = '';

    //get accessor
    get value(): any {
        return this.innerValue;
    };

    //set accessor including call the onchange callback
    set value(v: any) {
        if (v) {
            v = v.toString();
        }
        if (v !== this.innerValue) {
            this.innerValue = (v && v.length > 0) ? v : '';
            if (this.mask != undefined && this.mask.length > 0) {
                this.input(this.innerValue);
            }
            else {
                this.onChangeCallback(this.innerValue);
            }
        }
        this.checkValue();
    }

    private onTouchedCallback: () => void = noop;
    private onChangeCallback: (_: any) => void = noop;
  
    writeValue(v: string) {
        if (v) {
            v = v.toString();
        }
        if (v !== this.innerValue) {
            this.innerValue = (v && v.length > 0) ? v : '';
        }
        this.checkValue();
    }

    onFocus() {
        this.setFocus(true);
    }

    onBlur() {
        this.onTouchedCallback();
        this.setFocus(false);

        let valCurrentField: string = (this.element.nativeElement.value == undefined) ? '' : this.element.nativeElement.value;
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

    input(val, event?) {
        if (this.mask.length > 0) {
            let mascared: string = '';
            let unmask = val.toString().replace(new RegExp(/[^\d]/, 'g'), '');

            let c = 0;

            for (let i = 0; (i < this.mask.length) && (c < unmask.length); i++) {

                if (this.mask.slice(i, i + 1) == '9') {

                    mascared += unmask.slice(c, c + 1);
                    c++;

                } else {

                    mascared += this.mask.slice(i, i + 1);
                }
            }

            this.onChangeCallback(mascared);

            this.renderer.setElementProperty(this.element.nativeElement, 'value', mascared)

            setTimeout(function () {
                if (event !== undefined)
                    event.setSelectionRange(mascared.length, mascared.length);
            }, 0);
        } 
        else {
            this.onChangeCallback(val.toString());
            this.renderer.setElementProperty(this.element.nativeElement, 'value', val.toString())
        }
    }
}