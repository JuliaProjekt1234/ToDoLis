import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AppConstants } from 'src/app/constants/app-constants';

@Component({
  selector: 'color-picker',
  templateUrl: './color-picker.component.html',
  styleUrls: ['./color-picker.component.scss']
})
export class ColorPickerComponent {
  @Input() activeColor = AppConstants.ColorsToPicker[0];
  @Output() colorSelected = new EventEmitter<string>();
  
  public colors = AppConstants.ColorsToPicker;

  selectColor(color: string) {
    this.activeColor = color;
    this.colorSelected.emit(color);
  }

}
