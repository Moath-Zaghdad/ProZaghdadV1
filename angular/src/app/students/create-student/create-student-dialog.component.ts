import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter,
    ChangeDetectorRef
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
    CollegeDto,
    CollegeServiceProxy,
    CreateStudentDto,
    StudentServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-student-dialog.component.html'
})
export class CreateStudentDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    student: CreateStudentDto = new CreateStudentDto();
    colleges: CollegeDto[] = [];

    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _studentService: StudentServiceProxy,
        public _collegeService: CollegeServiceProxy,
        public bsModalRef: BsModalRef,
        private cd: ChangeDetectorRef,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.student.isActive = true;

        this._collegeService.getAll(undefined, 0, undefined).subscribe((result2) => {
            this.colleges = result2.items;
            this.cd.detectChanges();
        });
    }

    save(): void {
        this.saving = true;

        this._studentService.create(this.student).subscribe(
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
