import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter,
  ChangeDetectorRef,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CollegeServiceProxy,
  CollegeDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-college-dialog.component.html'
})
export class EditCollegeDialogComponent extends AppComponentBase
    implements OnInit {
  saving = false;
  college: CollegeDto = new CollegeDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
      injector: Injector,
      public _collegeService: CollegeServiceProxy,
      public bsModalRef: BsModalRef,
      private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._collegeService.get(this.id).subscribe((result: CollegeDto) => {
      this.college = result;
      this.cd.detectChanges();
    });
  }

  save(): void {
    this.saving = true;

    this._collegeService.update(this.college).subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
    );
  }
}
