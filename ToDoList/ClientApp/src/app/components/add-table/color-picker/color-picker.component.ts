import { Component, EventEmitter, Output } from '@angular/core';
import { AppConstants } from 'src/app/constants/app-constants';

@Component({
  selector: 'color-picker',
  templateUrl: './color-picker.component.html',
  styleUrls: ['./color-picker.component.scss']
})
export class ColorPickerComponent {
  @Output() colorSelected = new EventEmitter<string>();
  public colors = AppConstants.ColorsToPicker;
  public activeColor = AppConstants.ColorsToPicker[0];

  selectColor(color: string) {
    this.activeColor = color;
    this.colorSelected.emit(color);
  }

}
