import { FormGroup } from "@angular/forms";

export function getValueFromForm(form: FormGroup, controlName: string) {
    return form.controls[controlName].value;
}