import { Component, Input } from '@angular/core';
import { AppConstants } from 'src/app/constants/app-constants';

@Component({
  selector: 'color-picker-button',
  templateUrl: './color-picker-button.component.html',
  styleUrls: ['./color-picker-button.component.scss']
})
export class ColorPickerButtonComponent {
  @Input() color: string = "";
  @Input() activeColor = AppConstants.ColorsToPicker[0];
}
