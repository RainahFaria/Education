import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SchoolService } from '../../services/school.service';
import { School } from '../../models/school';
import { DataResponse } from '../../models/dataResponse';

@Component({
  selector: 'app-school',
  templateUrl: './school.component.html',
  styleUrls: ['./school.component.css']
})
export class SchoolComponent implements OnInit {
  school: School;  
  schoolForm: FormGroup;

  constructor(private schoolService: SchoolService,
    private fb: FormBuilder) { }

  ngOnInit() {
    this.schoolForm = this.fb.group({
      name: ['', Validators.required]
    });
  }

  getSchools(){

    this.schoolService.getAllSchools().subscribe((response: DataResponse) => {

    });

  }

  addSchool(){
    if (this.schoolForm.invalid) {
      return;
      // const message = this.sharedService.getInstantKey('USER_MESSAGES.REQUIRED_FIELD_NULL');
      // return this.sharedService.notification(message, 4000, MessageType.info);
    }
    this.schoolService.addSchool(this.school).subscribe((response: DataResponse) => {

    });

  }

}
