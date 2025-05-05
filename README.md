# Tes kemampuan teknis sebagai Backend programmer Bio Farma oleh - Arief Nugraha -

## Asumsi alur proses bisnis sistem :
1. Terdapat user dengan role *super admin* untuk mengelola data user.
2. User bisa menambah, mengedit, dan menghapus data obat.
3. User bisa menambah, mengedit, dan menghapus data bahan untuk membuat obat.
4. User bisa menambah, mengedit, dan menghapus data langkah pembuatan obat.
5. 1 obat bisa menggunakan bahan yang sama untuk membuat obat lainnya.
6. 1 obat bisa menggunakan satu atau lebih langkah yang sama untuk membuat obat lainnya.
7. 1 bahan bisa digunakan untuk membuat berbagai obat.

## ERD :
![tech-test-biofarma (1)](https://github.com/user-attachments/assets/8c79e341-8fa0-4f3e-ac6e-652f8f9a7e86)

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
4. production_steps
  - Daftar langkah-langkah pembuatan obat
  - setiap langkah pembuatan obat bisa menggunakan banyak bahan yang sama
5. substance_for_production
  - Sebagai tabel transaksi untuk menghubungkan resep obat, bahan, dan langkah pembuatan
  - Terdapat *next_step_id* untuk menyimpan langkah selanjutnya
  - Terdapat *prev_step_id* untuk menyimpan langkah sebelumnya

Setiap tabel memiliki data :
  - *create_date* untuk menyimpan kapan data ini dibuat
  - *update_date* untuk menyimpan kapan data ini diperbarui
  - *delete_date* untuk menyimpan kapan data ini dihapus (default = null)

## List API :
1. [POST] /login
2. [POST] /user
3. [GET] /user/{id}
4. [GET] /user/list
5. [PUT] /user/{id}
6. [DELETE] /user/{id}
7. [POST] /receipt
8. [GET] /receipt/{id}
9. [GET] /receipt/list
10. [PUT] /receipt/{id}
11. [DELETE] /receipt/{id}
12. [POST] /substance
13. [GET] /substance/{id}
14. [GET] /substance/list
15. [PUT] /substance/{id}
16. [DELETE] /substance/{id}
