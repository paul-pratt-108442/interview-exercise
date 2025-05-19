import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { ActivatedRoute, Router } from '@angular/router';

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

  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.fetchStaff();
    
    // Subscribe to route params
    this.route.params.subscribe(params => {
      const staffId = params['id'];
      if (staffId) {
        // Find and select the staff member once data is loaded
        if (this.staff.length > 0) {
          const staffMember = this.staff.find(s => s.staffId === +staffId);
          if (staffMember) {
            this.selectStaff(staffMember);
          }
        }
      }
    });
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

        // Check for route parameter after loading
        const staffId = this.route.snapshot.params['id'];
        if (staffId) {
          const staffMember = this.staff.find(s => s.staffId === +staffId);
          if (staffMember) {
            this.selectStaff(staffMember);
          }
        }
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
    this.router.navigate(['/staff', member.staffId]);
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
