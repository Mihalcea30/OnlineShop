import {Directive, ElementRef, HostListener} from '@angular/core';

@Directive({
  selector: '[appColor]'
})
export class ColorDirective {
  constructor(private elementRef: ElementRef) { }

  @HostListener('mouseenter') onMouseEnter() {
    this.highlight('blue');
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.highlight(null);
  }

  private highlight(color: string | null) {
    this.elementRef.nativeElement.style.backgroundColor = color;
  }

}
