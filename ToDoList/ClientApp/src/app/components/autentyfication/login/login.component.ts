import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';
import { getValueFromForm } from 'src/app/share/functions/forms/get-value-function';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  public loginForm: FormGroup = new FormGroup({});

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder
  ) {
    this.createForm();
  }

  private createForm() {
    this.loginForm = this.formBuilder.group({
      login: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    })
  }

  public submit() {
    if (this.loginForm.invalid) return;

    let user = new User(
      getValueFromForm(this.loginForm, "login"),
      getValueFromForm(this.loginForm, "password")
    )

    this.authService.login(user);
  }
}
