import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserToAdd } from 'src/app/models/user.model';
import { AuthHttpService } from 'src/app/services/http-services/auth-http-service';
import { getValueFromForm } from 'src/app/share/functions/forms/get-value-function';
import { mismatchValidationFunction } from 'src/app/share/functions/validators/mismatch-validation-function';

@Component({
  selector: 'registration',
  templateUrl: './registration.component.html',
})
export class RegistrationComponent {
  public registrationForm: FormGroup = new FormGroup({});

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private authHttpService: AuthHttpService
  ) {
    this.createForm();
  }

  private createForm() {
    this.registrationForm = this.formBuilder.group({
      login: new FormControl('', [Validators.required, Validators.minLength(5)]),
      password: new FormControl('', [Validators.required, Validators.minLength(5), mismatchValidationFunction('confirmPassword')]),
      confirmPassword: new FormControl('', [Validators.required, Validators.minLength(5), mismatchValidationFunction('password')])
    })
  }

  public submit() {
    if (this.registrationForm.invalid) return;

    let userToAdd = new UserToAdd(
      getValueFromForm(this.registrationForm, "login"),
      getValueFromForm(this.registrationForm, "password"),
      getValueFromForm(this.registrationForm, "confirmPassword"));

    this.authHttpService.registerUser(userToAdd).subscribe(()=>this.router.navigate(['/login']));
  }
}
