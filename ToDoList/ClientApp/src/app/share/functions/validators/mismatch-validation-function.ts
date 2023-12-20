import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function mismatchValidationFunction(compareControlName: string): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {

    if (!control?.value || !(control as any)?.parent?.controls[compareControlName]?.value) return null;

    if (control?.value !== (control as any)?.parent?.controls[compareControlName]?.value) {
      return { mismatch: true };
    }

    return null;
  };
}