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
  StudentServiceProxy,
  StudentDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-student-dialog.component.html'
})
export class EditStudentDialogComponent extends AppComponentBase
    implements OnInit {
  saving = false;
  student: StudentDto = new StudentDto();
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
      injector: Injector,
      public _studentService: StudentServiceProxy,
      public bsModalRef: BsModalRef,
      private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._studentService.get(this.id).subscribe((result: StudentDto) => {
      this.student = result;
      this.cd.detectChanges();
    });
  }

  save(): void {
    this.saving = true;

    this._studentService.update(this.student).subscribe(
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
