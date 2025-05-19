import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';

interface Course {
  courseId: number;
  courseName: string;
  staffId: number;
}

interface Staff {
  staffId: number;
  firstName: string;
  lastName: string;
  courses: Course[];
}

@Component({
  selector: 'app-staff',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatSidenavModule, MatListModule],
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent implements OnInit {
  staff: Staff[] = [];
  selectedStaff: Staff | null = null;
  courses: Course[] = [];
  loading = true;
  error = '';
  displayedColumns: string[] = ['staffId', 'firstName', 'lastName'];
  courseColumns: string[] = ['courseId', 'courseName', 'rosters'];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.fetchStaff();
  }

  fetchStaff() {
    this.http.get<Staff[]>('/api/staff').subscribe({
      next: (staff) => {
        this.staff = staff.map(member => ({
          ...member,
          firstName: member.firstName || '',
          lastName: member.lastName || '',
          courses: member.courses || []
        }));
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Failed to load staff';
        this.loading = false;
        console.error('Error fetching staff:', error);
      }
    });
  }

  selectStaff(member: Staff) {
    this.selectedStaff = member;
    this.fetchStaffCourses(member.staffId);
  }

  fetchStaffCourses(staffId: number) {
    this.http.get<Course[]>(`/api/staff/${staffId}/courses`).subscribe({
      next: (courses) => {
        this.courses = courses;
      },
      error: (error) => {
        console.error('Error fetching courses:', error);
        this.error = 'Failed to load courses';
      }
    });
  }
}
