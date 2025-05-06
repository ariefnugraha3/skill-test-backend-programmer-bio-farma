# Tes kemampuan teknis sebagai Backend programmer Bio Farma oleh - Arief Nugraha -

*Readme ini telah diedit untuk menyesuaikan dengan hasil program yang telah dikerjakan, jika ingin melihat desain/rancangan awal bisa dilihat di history commit*

## Asumsi alur proses bisnis sistem :
1. 1 obat bisa menggunakan bahan yang sama untuk membuat obat lainnya.
2. 1 obat bisa menggunakan satu atau lebih langkah yang sama untuk membuat obat lainnya.
3. 1 bahan bisa digunakan untuk membuat berbagai obat.

## ERD :
![tech-test-biofarma](https://github.com/user-attachments/assets/52213ecf-db75-4019-b923-4913de84967f)

Deskripsi tabel :
1. users
  - Daftar user yang bisa login dan menggunakan sistem ini
  - *role* terbagi dalam 2 jenis. 'Superadmin', bisa mengakses semua fitur termasuk menambah user baru atau mengedit user lama. 'Admin', user biasa yang bisa mengakses semua fitur kecuali mengelola user.
2. receipts
  - Daftar obat
  - setiap Obat bisa memiliki banyak bahan dan langkah pembuatan
3. substances
  - Daftar bahan-bahan yang dibutuhkan untuk membuat obat
  - setiap bahan bisa dipakai oleh banyak obat dan langkah pembuatan
4. production_step_details
  - Daftar detail dari langkah-langkah pembuatan obat
  - setiap langkah pembuatan obat bisa menggunakan banyak bahan yang sama
5. production_steps
  - Sebagai tabel transaksi untuk menghubungkan resep obat, bahan, dan langkah pembuatan
  - Terdapat *next_step_id* untuk menyimpan langkah selanjutnya
  - Terdapat *prev_step_id* untuk menyimpan langkah sebelumnya

Setiap tabel memiliki data :
  - *create_date* untuk menyimpan kapan data ini dibuat
  - *update_date* untuk menyimpan kapan data ini diperbarui

## List API :
1. [GET] /receipt
   - untuk melihat daftar resep obat
   - Request Payload : -
   - Response :
       - ![Screenshot 2025-05-06 204059](https://github.com/user-attachments/assets/47db5f10-b9c3-4775-a01e-868f099fbb5c)

2. [GET] /receipt/{id}
  - untuk melihat detail langkah pembuatan dan bahan yang digunakan untuk membuat obat
  - Request payload : receipt Id from route
  - Response :
      - ![Screenshot 2025-05-06 204059](https://github.com/user-attachments/assets/02b983ee-acc7-4533-8db1-2896bf37b01f)

---
#Cara menjalankan service
1. Buka medicine-receipt-service.sln
2. pastikan postgreSQL telah berjalan
3. pastikan telah mengisi data dalam database
4. Run ![image](https://github.com/user-attachments/assets/b72622fe-f6e0-4d55-b195-1d9d62072238)

