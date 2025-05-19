import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';

interface Course {
  id: number;
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
  imports: [CommonModule, MatTableModule],
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent implements OnInit {
  staff: Staff[] = [];
  loading = true;
  error = '';
  displayedColumns: string[] = ['staffId', 'firstName', 'lastName'];

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
}
