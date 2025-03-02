--
-- PostgreSQL database dump
--

-- Dumped from database version 17.2
-- Dumped by pg_dump version 17.2

-- Started on 2025-03-02 06:26:25

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 294 (class 1255 OID 16957)
-- Name: bilet_degistir(integer, integer, integer, integer, date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.bilet_degistir(p_kullanici_id integer, p_bilet_id integer, p_yeni_kalkis_sehir_id integer, p_yeni_varis_sehir_id integer, p_yeni_sefer_tarihi date) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Biletin gerçekten kullanıcıya ait olduğunu kontrol et
    IF NOT EXISTS (
        SELECT 1
        FROM biletler
        WHERE bilet_id = p_bilet_id
          AND kullanici_id = p_kullanici_id
    ) THEN
        RAISE EXCEPTION 'Bilet kullanıcıya ait değil!';
    END IF;

    -- Bileti güncelle
    UPDATE biletler
    SET sefer_id = (
            SELECT sefer_id
            FROM seferler
            WHERE kalkis_sehir_id = p_yeni_kalkis_sehir_id
              AND varis_sehir_id = p_yeni_varis_sehir_id
              AND tarih = p_yeni_sefer_tarihi
            LIMIT 1
    )
    WHERE bilet_id = p_bilet_id;

    -- Eğer sefer bulunmazsa hata mesajı ver
    IF NOT FOUND THEN
        RAISE EXCEPTION 'Yeni sefer bulunamadı!';
    END IF;
END;
$$;


ALTER FUNCTION public.bilet_degistir(p_kullanici_id integer, p_bilet_id integer, p_yeni_kalkis_sehir_id integer, p_yeni_varis_sehir_id integer, p_yeni_sefer_tarihi date) OWNER TO postgres;

--
-- TOC entry 290 (class 1255 OID 16955)
-- Name: bilet_iptali(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.bilet_iptali(p_bilet_id integer, p_kullanici_id integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Kullanıcıya ait biletin olup olmadığını kontrol et
    IF NOT EXISTS (
        SELECT 1 
        FROM biletler 
        WHERE bilet_id = p_bilet_id AND kullanici_id = p_kullanici_id
    ) THEN
        RAISE EXCEPTION 'Bu bilet, belirtilen kullanıcıya ait değildir.';
    END IF;

    -- İlk olarak, bilet ile ilişkili ödemeyi sil
    DELETE FROM odemeler
    WHERE bilet_id = p_bilet_id;

    -- Şimdi, biletin kendisini sil
    DELETE FROM biletler
    WHERE bilet_id = p_bilet_id AND kullanici_id = p_kullanici_id;
    
    -- Başarılı işlem mesajı
    RAISE NOTICE 'Bilet ve ödemesi başarıyla iptal edildi.';
END;
$$;


ALTER FUNCTION public.bilet_iptali(p_bilet_id integer, p_kullanici_id integer) OWNER TO postgres;

--
-- TOC entry 280 (class 1255 OID 16942)
-- Name: bileteklendiginderezervasyonguncelle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.bileteklendiginderezervasyonguncelle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Rezervasyon durumunu kontrol et ve güncelle
    PERFORM GuncelleRezervasyonDurumu(NEW.kullanici_id, NEW.sefer_id);

    RETURN NEW;
END;
$$;


ALTER FUNCTION public.bileteklendiginderezervasyonguncelle() OWNER TO postgres;

--
-- TOC entry 291 (class 1255 OID 16954)
-- Name: bileti_odemeye_ekle(integer, text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.bileti_odemeye_ekle(p_bilet_id integer, p_odeme_turu text) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Ödemeyi ekle
    INSERT INTO odemeler (bilet_id, odeme_turu, tutar, odeme_tarihi)
    SELECT b.bilet_id, p_odeme_turu, b.fiyat, NOW()
    FROM biletler b
    WHERE b.bilet_id = p_bilet_id;
END;
$$;


ALTER FUNCTION public.bileti_odemeye_ekle(p_bilet_id integer, p_odeme_turu text) OWNER TO postgres;

--
-- TOC entry 283 (class 1255 OID 16936)
-- Name: biletiodemeyedonustur(integer, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.biletiodemeyedonustur(p_bilet_id integer, p_odeme_turu character varying) RETURNS void
    LANGUAGE plpgsql
    AS $$
DECLARE
    tutar DECIMAL(10, 2);
BEGIN
    -- Bilet fiyatını al
    SELECT b.fiyat
    INTO tutar
    FROM biletler b -- Tablo adı net bir şekilde belirtilir
    WHERE b.bilet_id = p_bilet_id;

    -- Ödeme oluştur
    INSERT INTO odemeler (bilet_id, odeme_turu, tutar, odeme_tarihi)
    VALUES (p_bilet_id, p_odeme_turu, tutar, CURRENT_TIMESTAMP);
END;
$$;


ALTER FUNCTION public.biletiodemeyedonustur(p_bilet_id integer, p_odeme_turu character varying) OWNER TO postgres;

--
-- TOC entry 262 (class 1255 OID 16926)
-- Name: ekle_kullanici(character varying, character varying, character varying, character varying, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ekle_kullanici(p_ad character varying, p_soyad character varying, p_email character varying, p_sifre character varying, p_telefon character varying) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO kullanicilar (ad, soy_ad, email, "Kullancici_Sifre", telefon)
    VALUES (p_ad, p_soyad, p_email, p_sifre, p_telefon);
END;
$$;


ALTER FUNCTION public.ekle_kullanici(p_ad character varying, p_soyad character varying, p_email character varying, p_sifre character varying, p_telefon character varying) OWNER TO postgres;

--
-- TOC entry 284 (class 1255 OID 16931)
-- Name: ekle_rezervasyon(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.ekle_rezervasyon(p_kullanici_id integer, p_sefer_id integer) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO rezervasyonlar (kullanici_id, sefer_id, durum, rezervasyon_tarihi)
    VALUES (p_kullanici_id, p_sefer_id, 'Ödenmedi', NOW());
END;
$$;


ALTER FUNCTION public.ekle_rezervasyon(p_kullanici_id integer, p_sefer_id integer) OWNER TO postgres;

--
-- TOC entry 264 (class 1255 OID 16929)
-- Name: get_kullanici_id(character varying, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_kullanici_id(p_ad character varying, p_sifre character varying) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    result INTEGER;
BEGIN
    -- Kullanıcıyı sorgula
    SELECT kullanici_id
    INTO result
    FROM kullanicilar
    WHERE ad = p_ad AND "Kullancici_Sifre" = p_sifre;

    -- Eğer kullanıcı yoksa NULL döndür
    IF NOT FOUND THEN
        RETURN NULL;
    END IF;

    RETURN result;
END;
$$;


ALTER FUNCTION public.get_kullanici_id(p_ad character varying, p_sifre character varying) OWNER TO postgres;

--
-- TOC entry 279 (class 1255 OID 16932)
-- Name: get_rezervasyonlar(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_rezervasyonlar(p_kullanici_id integer) RETURNS TABLE(rezervasyon_id integer, sefer_id integer, durum character varying, rezervasyon_tarihi timestamp without time zone, kalkis_sehir_id integer, varis_sehir_id integer, sefer_tarihi date, sefer_saati time without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        r.rezervasyon_id,
        r.sefer_id,
        r.durum,
        r.rezervasyon_tarihi,
        s.kalkis_sehir_id,
        s.varis_sehir_id,
        s.tarih AS sefer_tarihi,
        s.saat AS sefer_saati
    FROM 
        rezervasyonlar r
    JOIN 
        seferler s ON r.sefer_id = s.sefer_id
    WHERE 
        r.kullanici_id = p_kullanici_id;
END;
$$;


ALTER FUNCTION public.get_rezervasyonlar(p_kullanici_id integer) OWNER TO postgres;

--
-- TOC entry 261 (class 1255 OID 16806)
-- Name: kampanyaekle(integer, character varying, numeric, date, date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kampanyaekle(firmaid integer, aciklama character varying, oran numeric, baslangic date, bitis date) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Kampanyalar (Firma_ID, Aciklama, Oran, Baslangis_Tarihi, Bitis_Tarihi)
    VALUES (firmaID, aciklama, oran, baslangic, bitis);
END;
$$;


ALTER FUNCTION public.kampanyaekle(firmaid integer, aciklama character varying, oran numeric, baslangic date, bitis date) OWNER TO postgres;

--
-- TOC entry 259 (class 1255 OID 16802)
-- Name: kampanyasonuindirimguncelle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kampanyasonuindirimguncelle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE Indirimler
    SET Gecerlik_Durumu = FALSE
    WHERE Kampanya_ID = OLD.Kampanya_ID;
    RETURN OLD;
END;
$$;


ALTER FUNCTION public.kampanyasonuindirimguncelle() OWNER TO postgres;

--
-- TOC entry 285 (class 1255 OID 16949)
-- Name: kontrol_odeme(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kontrol_odeme(p_bilet_id integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN EXISTS (
        SELECT 1
        FROM odemeler
        WHERE bilet_id = p_bilet_id
    );
END;
$$;


ALTER FUNCTION public.kontrol_odeme(p_bilet_id integer) OWNER TO postgres;

--
-- TOC entry 286 (class 1255 OID 16946)
-- Name: kontrol_rezervasyon(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kontrol_rezervasyon(p_rezervasyon_id integer, p_kullanici_id integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    rezervasyon_durumu TEXT;
BEGIN
    -- Rezervasyonun durumunu kontrol et
    SELECT durum 
    INTO rezervasyon_durumu
    FROM rezervasyonlar
    WHERE rezervasyon_id = p_rezervasyon_id
      AND kullanici_id = p_kullanici_id;

    -- Eğer rezervasyon bulunamazsa veya durumu 'ödendi' ise FALSE döndür
    IF rezervasyon_durumu IS NULL OR rezervasyon_durumu = 'Ödendi' THEN
        RETURN FALSE;
    END IF;

    -- Aksi durumda TRUE döndür
    RETURN TRUE;
END;
$$;


ALTER FUNCTION public.kontrol_rezervasyon(p_rezervasyon_id integer, p_kullanici_id integer) OWNER TO postgres;

--
-- TOC entry 281 (class 1255 OID 16934)
-- Name: kontrolrezervasyon(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kontrolrezervasyon(p_kullanici_id integer, p_rezervasyon_id integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    varMi BOOLEAN;
BEGIN
    -- Kullanıcı ve rezervasyon ID'sini kontrol et
    SELECT EXISTS (
        SELECT 1
        FROM rezervasyonlar
        WHERE kullanici_id = p_kullanici_id
          AND rezervasyon_id = p_rezervasyon_id
    )
    INTO varMi;

    RETURN varMi;
END;
$$;


ALTER FUNCTION public.kontrolrezervasyon(p_kullanici_id integer, p_rezervasyon_id integer) OWNER TO postgres;

--
-- TOC entry 265 (class 1255 OID 16930)
-- Name: kontrolseferid(integer, integer, date, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kontrolseferid(kalkis integer, varis integer, aramatarihi date, secilenseferid integer) RETURNS boolean
    LANGUAGE plpgsql
    AS $$
DECLARE
    varMi BOOLEAN;
BEGIN
    SELECT EXISTS (
        SELECT 1
        FROM Seferler s
        WHERE 
            s.Sefer_ID = secilenSeferID
            AND s.Kalkis_Sehir_ID = kalkis
            AND s.Varis_Sehir_ID = varis
            AND s.Tarih = aramaTarihi
    )
    INTO varMi;

    RETURN varMi; -- Eğer SeferID uygun seferler listesinde varsa TRUE döner
END;
$$;


ALTER FUNCTION public.kontrolseferid(kalkis integer, varis integer, aramatarihi date, secilenseferid integer) OWNER TO postgres;

--
-- TOC entry 278 (class 1255 OID 16928)
-- Name: kullanici_giris_kontrolu(text, text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kullanici_giris_kontrolu(kullanici_adi text, sifre text) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    kullanici_id INTEGER;
BEGIN
    -- Kullanıcı bilgilerini kontrol et ve id'yi al
    SELECT kullanici_id
    INTO kullanici_id
    FROM kullanicilar
    WHERE ad = kullanici_adi AND Kullancici_Sifre = sifre;

    -- Eğer kullanıcı bulunamazsa NULL döner
    IF kullanici_id IS NULL THEN
        RAISE EXCEPTION 'Geçersiz kullanıcı adı veya şifre';
    END IF;

    RETURN kullanici_id;
END;
$$;


ALTER FUNCTION public.kullanici_giris_kontrolu(kullanici_adi text, sifre text) OWNER TO postgres;

--
-- TOC entry 293 (class 1255 OID 16959)
-- Name: kullaniciya_ait_biletler(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kullaniciya_ait_biletler(p_kullanici_id integer) RETURNS TABLE(bilet_id integer, kullanici_id integer, fiyat numeric, rezervasyon_id integer, kalkis_sehir_id integer, varis_sehir_id integer, sefer_tarihi date, kalkis_sehir_adi character varying, varis_sehir_adi character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        b.bilet_id, 
        b.kullanici_id, 
        b.fiyat, 
        b.rezervasyon_id, 
        s.kalkis_sehir_id, 
        s.varis_sehir_id, 
        s.tarih,
        ks.ad AS kalkis_sehir_adi,  -- 'ad' olarak güncellendi
        vs.ad AS varis_sehir_adi   -- 'ad' olarak güncellendi
    FROM 
        biletler b
    JOIN 
        seferler s ON b.sefer_id = s.sefer_id
    JOIN 
        sehirler ks ON s.kalkis_sehir_id = ks.sehir_id
    JOIN 
        sehirler vs ON s.varis_sehir_id = vs.sehir_id
    WHERE 
        b.kullanici_id = p_kullanici_id;
END;
$$;


ALTER FUNCTION public.kullaniciya_ait_biletler(p_kullanici_id integer) OWNER TO postgres;

--
-- TOC entry 287 (class 1255 OID 16974)
-- Name: kullaniciyaaitseferdurumlari(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.kullaniciyaaitseferdurumlari(p_kullanici_id integer, p_sefer_id integer) RETURNS TABLE(sefer_durumu_id integer, sefer_id integer, durum character varying, aciklama text, kullanici_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        sd.sefer_durumu_id,
        sd.sefer_id,
        sd.durum,
        sd.aciklama,
        b.kullanici_id
    FROM 
        Sefer_Durumlari sd
    JOIN 
        Biletler b ON b.sefer_id = sd.sefer_id
    WHERE 
        b.kullanici_id = p_kullanici_id
        AND sd.sefer_id = p_sefer_id;
END;
$$;


ALTER FUNCTION public.kullaniciyaaitseferdurumlari(p_kullanici_id integer, p_sefer_id integer) OWNER TO postgres;

--
-- TOC entry 289 (class 1255 OID 16952)
-- Name: rezervasyon_isle(integer, integer, text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.rezervasyon_isle(p_rezervasyon_id integer, p_kullanici_id integer, p_odeme_turu text) RETURNS text
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_bilet_id INTEGER; -- PL/pgSQL değişkeni
BEGIN
    -- Rezervasyon kullanıcıya ait mi?
    IF NOT kontrol_rezervasyon(p_kullanici_id, p_rezervasyon_id) THEN
        RETURN 'Rezervasyon kullanıcıya ait değil!';
    END IF;

    -- Daha önce ödeme yapılmış mı?
    SELECT b.bilet_id
    INTO v_bilet_id
    FROM biletler b
    WHERE b.rezervasyon_id = p_rezervasyon_id;

    IF kontrol_odeme(v_bilet_id) THEN
        RETURN 'Bu rezervasyon için zaten ödeme yapılmış.';
    END IF;

    -- Bilet oluştur ve ödeme kaydı ekle
    INSERT INTO biletler (rezervasyon_id)
    VALUES (p_rezervasyon_id)
    RETURNING bilet_id INTO v_bilet_id;

    INSERT INTO odemeler (bilet_id, odeme_turu, odeme_tarihi)
    VALUES (v_bilet_id, p_odeme_turu, NOW());

    -- Rezervasyonu güncelle
    UPDATE rezervasyonlar
    SET durum = 'Ödendi'
    WHERE rezervasyon_id = p_rezervasyon_id;

    RETURN 'Bilet oluşturuldu, ödeme işlemi tamamlandı ve rezervasyon güncellendi.';
END;
$$;


ALTER FUNCTION public.rezervasyon_isle(p_rezervasyon_id integer, p_kullanici_id integer, p_odeme_turu text) OWNER TO postgres;

--
-- TOC entry 288 (class 1255 OID 16951)
-- Name: rezervasyon_isle(integer, integer, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.rezervasyon_isle(p_rezervasyon_id integer, p_kullanici_id integer, p_odeme_turu character varying) RETURNS void
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_bilet_id INTEGER;
BEGIN
    -- Önce rezervasyonu kontrol et
    IF NOT kontrol_rezervasyon(p_kullanici_id, p_rezervasyon_id) THEN
        RAISE EXCEPTION 'Bu rezervasyon size ait değil veya bulunamadı.';
    END IF;

    -- Daha önce ödeme yapılmış mı kontrol et
    IF kontrol_odeme((SELECT bilet_id FROM biletler WHERE rezervasyon_id = p_rezervasyon_id)) THEN
        RAISE EXCEPTION 'Bu rezervasyon için zaten ödeme yapılmış.';
    END IF;

    -- Bileti oluştur
    INSERT INTO biletler (kullanici_id, fiyat)
    SELECT r.kullanici_id, r.fiyat
    FROM rezervasyonlar r
    WHERE r.rezervasyon_id = p_rezervasyon_id
    RETURNING bilet_id INTO v_bilet_id;

    -- Ödemeyi ekle
    INSERT INTO odemeler (bilet_id, odeme_turu)
    VALUES (v_bilet_id, p_odeme_turu);

    -- Rezervasyon durumunu güncelle
    UPDATE rezervasyonlar
    SET durum = 'Ödendi'
    WHERE rezervasyon_id = p_rezervasyon_id;
END;
$$;


ALTER FUNCTION public.rezervasyon_isle(p_rezervasyon_id integer, p_kullanici_id integer, p_odeme_turu character varying) OWNER TO postgres;

--
-- TOC entry 292 (class 1255 OID 16953)
-- Name: rezervasyonu_bilete_donustur(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.rezervasyonu_bilete_donustur(p_rezervasyon_id integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    yeni_bilet_id INT;
BEGIN
    -- Rezervasyona ait bilgileri bilet tablosuna ekle
    INSERT INTO biletler (kullanici_id, sefer_id, fiyat, rezervasyon_id)
    SELECT kullanici_id, sefer_id, -- Kullanıcı ID ve Sefer ID
           100.0, -- Örnek fiyat (dinamik olabilir)
           rezervasyon_id
    FROM rezervasyonlar r
    WHERE r.rezervasyon_id = p_rezervasyon_id
    RETURNING bilet_id INTO yeni_bilet_id;

    -- Rezervasyonun durumunu 'ödendi' olarak güncelle
    UPDATE rezervasyonlar
    SET durum = 'Ödendi'
    WHERE rezervasyon_id = p_rezervasyon_id;

    -- Yeni oluşturulan biletin ID'sini döndür
    RETURN yeni_bilet_id;
END;
$$;


ALTER FUNCTION public.rezervasyonu_bilete_donustur(p_rezervasyon_id integer) OWNER TO postgres;

--
-- TOC entry 282 (class 1255 OID 16939)
-- Name: rezervasyonubiletedonustur(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.rezervasyonubiletedonustur(p_rezervasyon_id integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$
DECLARE
    kullaniciId INT;
    seferId INT;
    koltukNumarasi VARCHAR(10) DEFAULT '1A'; -- Varsayılan koltuk numarası
    fiyat DECIMAL(10, 2);
    yeniBiletId INT;
BEGIN
    -- Rezervasyon bilgilerini al
    SELECT r.kullanici_id, r.sefer_id, 100.00 -- Varsayılan fiyat
    INTO kullaniciId, seferId, fiyat
    FROM rezervasyonlar r
    WHERE r.rezervasyon_id = p_rezervasyon_id;

    -- Yeni bilet oluştur
    INSERT INTO biletler (kullanici_id, sefer_id, koltuk_numarasi, fiyat)
    VALUES (kullaniciId, seferId, koltukNumarasi, fiyat)
    RETURNING bilet_id
    INTO yeniBiletId;

    RETURN yeniBiletId;
END;
$$;


ALTER FUNCTION public.rezervasyonubiletedonustur(p_rezervasyon_id integer) OWNER TO postgres;

--
-- TOC entry 295 (class 1255 OID 16960)
-- Name: sefer_durumu_ekle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sefer_durumu_ekle() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Sefer_Durumlari (sefer_id, durum, aciklama)
    VALUES (NEW.sefer_id, 'Planlandı', 'Yeni sefer planlandı.');
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.sefer_durumu_ekle() OWNER TO postgres;

--
-- TOC entry 266 (class 1255 OID 16969)
-- Name: sikayetekle(integer, text); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.sikayetekle(p_kullanici_id integer, p_sikayet_metni text) RETURNS void
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO sikayetler (kullanici_id, sikayet_metni, sikayet_tarihi)
    VALUES (p_kullanici_id, p_sikayet_metni, CURRENT_TIMESTAMP);
END;
$$;


ALTER FUNCTION public.sikayetekle(p_kullanici_id integer, p_sikayet_metni text) OWNER TO postgres;

--
-- TOC entry 257 (class 1255 OID 16793)
-- Name: uygunseferler(integer, integer, date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.uygunseferler(kalkis integer, varis integer, aramatarihi date) RETURNS TABLE(seferid integer, firmaad character varying, kalkissehir character varying, varissehir character varying, tarih date, saat time without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY 
    SELECT 
        s.Sefer_ID, f.Ad AS FirmaAd, ks.Ad AS KalkisSehir, vs.Ad AS VarisSehir, s.Tarih, s.Saat
    FROM 
        Seferler s
    JOIN Firmalar f ON s.Firma_ID = f.Firma_ID
    JOIN Sehirler ks ON s.Kalkis_Sehir_ID = ks.Sehir_ID
    JOIN Sehirler vs ON s.Varis_Sehir_ID = vs.Sehir_ID
    WHERE 
        s.Kalkis_Sehir_ID = kalkis 
        AND s.Varis_Sehir_ID = varis 
        AND s.Tarih = aramaTarihi;
END;
$$;


ALTER FUNCTION public.uygunseferler(kalkis integer, varis integer, aramatarihi date) OWNER TO postgres;

--
-- TOC entry 260 (class 1255 OID 16804)
-- Name: uygunseferlerigetir(integer, integer, date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.uygunseferlerigetir(kalkis integer, varis integer, aramatarihi date) RETURNS TABLE(seferid integer, firmaad character varying, kalkissehir character varying, varissehir character varying, tarih date, saat time without time zone)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY 
    SELECT 
        s.Sefer_ID, f.Ad AS FirmaAd, ks.Ad AS KalkisSehir, vs.Ad AS VarisSehir, s.Tarih, s.Saat
    FROM 
        Seferler s
    JOIN Firmalar f ON s.Firma_ID = f.Firma_ID
    JOIN Sehirler ks ON s.Kalkis_Sehir_ID = ks.Sehir_ID
    JOIN Sehirler vs ON s.Varis_Sehir_ID = vs.Sehir_ID
    WHERE 
        s.Kalkis_Sehir_ID = kalkis 
        AND s.Varis_Sehir_ID = varis 
        AND s.Tarih = aramaTarihi;
END;
$$;


ALTER FUNCTION public.uygunseferlerigetir(kalkis integer, varis integer, aramatarihi date) OWNER TO postgres;

--
-- TOC entry 258 (class 1255 OID 16794)
-- Name: yenibiletlog(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.yenibiletlog() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO Islem_Loglari (Kullanici_ID, Islem_Turu, Islem_Tarihi)
    VALUES (NEW.Kullanici_ID, 'Bilet Alındı', CURRENT_TIMESTAMP);
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.yenibiletlog() OWNER TO postgres;

--
-- TOC entry 263 (class 1255 OID 16966)
-- Name: yenisikayetlog(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.yenisikayetlog() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    INSERT INTO islem_Loglari (Kullanici_ID, Islem_Turu, Islem_Tarihi)
    VALUES (NEW.Kullanici_ID, 'Şikayet Eklendi', CURRENT_TIMESTAMP);
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.yenisikayetlog() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 222 (class 1259 OID 16489)
-- Name: araclar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.araclar (
    arac_id integer NOT NULL,
    tur character varying(50),
    kapasite integer,
    firma_id integer
);


ALTER TABLE public.araclar OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16488)
-- Name: araclar_arac_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.araclar_arac_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.araclar_arac_id_seq OWNER TO postgres;

--
-- TOC entry 5151 (class 0 OID 0)
-- Dependencies: 221
-- Name: araclar_arac_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.araclar_arac_id_seq OWNED BY public.araclar.arac_id;


--
-- TOC entry 238 (class 1259 OID 16610)
-- Name: bagajlar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.bagajlar (
    bagaj_id integer NOT NULL,
    bilet_id integer,
    agirlik numeric(10,2),
    boyut character varying(50),
    firma_id integer
);


ALTER TABLE public.bagajlar OWNER TO postgres;

--
-- TOC entry 237 (class 1259 OID 16609)
-- Name: bagajlar_bagaj_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.bagajlar_bagaj_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.bagajlar_bagaj_id_seq OWNER TO postgres;

--
-- TOC entry 5152 (class 0 OID 0)
-- Dependencies: 237
-- Name: bagajlar_bagaj_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.bagajlar_bagaj_id_seq OWNED BY public.bagajlar.bagaj_id;


--
-- TOC entry 228 (class 1259 OID 16535)
-- Name: biletler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.biletler (
    bilet_id integer NOT NULL,
    kullanici_id integer,
    sefer_id integer,
    koltuk_numarasi character varying(10),
    fiyat numeric(10,2),
    rezervasyon_id integer
);


ALTER TABLE public.biletler OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 16534)
-- Name: biletler_bilet_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.biletler_bilet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.biletler_bilet_id_seq OWNER TO postgres;

--
-- TOC entry 5153 (class 0 OID 0)
-- Dependencies: 227
-- Name: biletler_bilet_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.biletler_bilet_id_seq OWNED BY public.biletler.bilet_id;


--
-- TOC entry 220 (class 1259 OID 16482)
-- Name: firmalar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.firmalar (
    firma_id integer NOT NULL,
    ad character varying(100),
    telefon_numarasi character varying(15),
    gmail character varying(100),
    adres character varying(255)
);


ALTER TABLE public.firmalar OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16481)
-- Name: firmalar_firma_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.firmalar_firma_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.firmalar_firma_id_seq OWNER TO postgres;

--
-- TOC entry 5154 (class 0 OID 0)
-- Dependencies: 219
-- Name: firmalar_firma_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.firmalar_firma_id_seq OWNED BY public.firmalar.firma_id;


--
-- TOC entry 244 (class 1259 OID 16684)
-- Name: hizmetler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.hizmetler (
    hizmet_id integer NOT NULL,
    ad character varying(100),
    ucret numeric(10,2),
    firma_id integer
);


ALTER TABLE public.hizmetler OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 16683)
-- Name: hizmetler_hizmet_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.hizmetler_hizmet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.hizmetler_hizmet_id_seq OWNER TO postgres;

--
-- TOC entry 5155 (class 0 OID 0)
-- Dependencies: 243
-- Name: hizmetler_hizmet_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.hizmetler_hizmet_id_seq OWNED BY public.hizmetler.hizmet_id;


--
-- TOC entry 234 (class 1259 OID 16581)
-- Name: indirimler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.indirimler (
    indirim_id integer NOT NULL,
    kullanici_id integer,
    kampanya_id integer,
    gecerlik_durumu boolean
);


ALTER TABLE public.indirimler OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 16580)
-- Name: indirimler_indirim_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.indirimler_indirim_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.indirimler_indirim_id_seq OWNER TO postgres;

--
-- TOC entry 5156 (class 0 OID 0)
-- Dependencies: 233
-- Name: indirimler_indirim_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.indirimler_indirim_id_seq OWNED BY public.indirimler.indirim_id;


--
-- TOC entry 246 (class 1259 OID 16696)
-- Name: islem_loglari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.islem_loglari (
    log_id integer NOT NULL,
    kullanici_id integer,
    islem_turu character varying(100),
    islem_tarihi timestamp without time zone
);


ALTER TABLE public.islem_loglari OWNER TO postgres;

--
-- TOC entry 245 (class 1259 OID 16695)
-- Name: islem_loglari_log_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.islem_loglari_log_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.islem_loglari_log_id_seq OWNER TO postgres;

--
-- TOC entry 5157 (class 0 OID 0)
-- Dependencies: 245
-- Name: islem_loglari_log_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.islem_loglari_log_id_seq OWNED BY public.islem_loglari.log_id;


--
-- TOC entry 256 (class 1259 OID 16781)
-- Name: istasyonlar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.istasyonlar (
    istasyon_id integer NOT NULL,
    ad character varying(100),
    tur character varying(50),
    sehir_id integer
);


ALTER TABLE public.istasyonlar OWNER TO postgres;

--
-- TOC entry 255 (class 1259 OID 16780)
-- Name: istasyonlar_istasyon_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.istasyonlar_istasyon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.istasyonlar_istasyon_id_seq OWNER TO postgres;

--
-- TOC entry 5158 (class 0 OID 0)
-- Dependencies: 255
-- Name: istasyonlar_istasyon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.istasyonlar_istasyon_id_seq OWNED BY public.istasyonlar.istasyon_id;


--
-- TOC entry 232 (class 1259 OID 16569)
-- Name: kampanyalar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kampanyalar (
    kampanya_id integer NOT NULL,
    firma_id integer,
    aciklama character varying(255),
    oran numeric(5,2),
    baslangis_tarihi date,
    bitis_tarihi date
);


ALTER TABLE public.kampanyalar OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 16568)
-- Name: kampanyalar_kampanya_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kampanyalar_kampanya_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kampanyalar_kampanya_id_seq OWNER TO postgres;

--
-- TOC entry 5159 (class 0 OID 0)
-- Dependencies: 231
-- Name: kampanyalar_kampanya_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kampanyalar_kampanya_id_seq OWNED BY public.kampanyalar.kampanya_id;


--
-- TOC entry 218 (class 1259 OID 16473)
-- Name: kullanicilar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kullanicilar (
    kullanici_id integer NOT NULL,
    ad character varying(50),
    soy_ad character varying(50),
    email character varying(100),
    "Kullancici_Sifre" character varying(255),
    telefon character varying(15)
);


ALTER TABLE public.kullanicilar OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16472)
-- Name: kullanıcılar_kullanici_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."kullanıcılar_kullanici_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."kullanıcılar_kullanici_id_seq" OWNER TO postgres;

--
-- TOC entry 5160 (class 0 OID 0)
-- Dependencies: 217
-- Name: kullanıcılar_kullanici_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."kullanıcılar_kullanici_id_seq" OWNED BY public.kullanicilar.kullanici_id;


--
-- TOC entry 236 (class 1259 OID 16598)
-- Name: odemeler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.odemeler (
    odeme_id integer NOT NULL,
    bilet_id integer,
    odeme_turu character varying(50),
    tutar numeric(10,2),
    odeme_tarihi timestamp without time zone
);


ALTER TABLE public.odemeler OWNER TO postgres;

--
-- TOC entry 235 (class 1259 OID 16597)
-- Name: odemeler_odeme_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.odemeler_odeme_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.odemeler_odeme_id_seq OWNER TO postgres;

--
-- TOC entry 5161 (class 0 OID 0)
-- Dependencies: 235
-- Name: odemeler_odeme_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.odemeler_odeme_id_seq OWNED BY public.odemeler.odeme_id;


--
-- TOC entry 252 (class 1259 OID 16728)
-- Name: otobusler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.otobusler (
    otobus_id integer NOT NULL,
    katlar integer DEFAULT 1 NOT NULL,
    wifi boolean DEFAULT false
)
INHERITS (public.araclar);


ALTER TABLE public.otobusler OWNER TO postgres;

--
-- TOC entry 251 (class 1259 OID 16727)
-- Name: otobusler_otobus_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.otobusler_otobus_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.otobusler_otobus_id_seq OWNER TO postgres;

--
-- TOC entry 5162 (class 0 OID 0)
-- Dependencies: 251
-- Name: otobusler_otobus_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.otobusler_otobus_id_seq OWNED BY public.otobusler.otobus_id;


--
-- TOC entry 254 (class 1259 OID 16751)
-- Name: personel; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.personel (
    personel_id integer NOT NULL,
    ad character varying(50),
    soy_ad character varying(50),
    arac_id integer,
    gorev_turu character varying(50),
    firma_id integer
);


ALTER TABLE public.personel OWNER TO postgres;

--
-- TOC entry 253 (class 1259 OID 16750)
-- Name: personel_personel_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.personel_personel_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.personel_personel_id_seq OWNER TO postgres;

--
-- TOC entry 5163 (class 0 OID 0)
-- Dependencies: 253
-- Name: personel_personel_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.personel_personel_id_seq OWNED BY public.personel.personel_id;


--
-- TOC entry 230 (class 1259 OID 16552)
-- Name: rezervasyonlar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rezervasyonlar (
    rezervasyon_id integer NOT NULL,
    kullanici_id integer,
    sefer_id integer,
    durum character varying(50) DEFAULT 'Ödenmedi'::character varying,
    rezervasyon_tarihi timestamp without time zone
);


ALTER TABLE public.rezervasyonlar OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 16551)
-- Name: rezervasyonlar_rezervasyon_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.rezervasyonlar_rezervasyon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.rezervasyonlar_rezervasyon_id_seq OWNER TO postgres;

--
-- TOC entry 5164 (class 0 OID 0)
-- Dependencies: 229
-- Name: rezervasyonlar_rezervasyon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.rezervasyonlar_rezervasyon_id_seq OWNED BY public.rezervasyonlar.rezervasyon_id;


--
-- TOC entry 242 (class 1259 OID 16641)
-- Name: sefer_durumlari; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sefer_durumlari (
    sefer_durumu_id integer NOT NULL,
    sefer_id integer,
    durum character varying(50),
    aciklama text
);


ALTER TABLE public.sefer_durumlari OWNER TO postgres;

--
-- TOC entry 241 (class 1259 OID 16640)
-- Name: sefer_durumlari_sefer_durumu_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sefer_durumlari_sefer_durumu_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sefer_durumlari_sefer_durumu_id_seq OWNER TO postgres;

--
-- TOC entry 5165 (class 0 OID 0)
-- Dependencies: 241
-- Name: sefer_durumlari_sefer_durumu_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sefer_durumlari_sefer_durumu_id_seq OWNED BY public.sefer_durumlari.sefer_durumu_id;


--
-- TOC entry 226 (class 1259 OID 16508)
-- Name: seferler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.seferler (
    sefer_id integer NOT NULL,
    arac_id integer,
    kalkis_sehir_id integer,
    varis_sehir_id integer,
    firma_id integer,
    tarih date,
    saat time without time zone,
    seyahatturu character varying(10) DEFAULT 'Otobüs'::character varying NOT NULL
);


ALTER TABLE public.seferler OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 16507)
-- Name: seferler_sefer_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.seferler_sefer_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.seferler_sefer_id_seq OWNER TO postgres;

--
-- TOC entry 5166 (class 0 OID 0)
-- Dependencies: 225
-- Name: seferler_sefer_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.seferler_sefer_id_seq OWNED BY public.seferler.sefer_id;


--
-- TOC entry 224 (class 1259 OID 16501)
-- Name: sehirler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sehirler (
    sehir_id integer NOT NULL,
    ad character varying(100)
);


ALTER TABLE public.sehirler OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 16500)
-- Name: sehirler_sehir_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sehirler_sehir_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sehirler_sehir_id_seq OWNER TO postgres;

--
-- TOC entry 5167 (class 0 OID 0)
-- Dependencies: 223
-- Name: sehirler_sehir_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sehirler_sehir_id_seq OWNED BY public.sehirler.sehir_id;


--
-- TOC entry 240 (class 1259 OID 16627)
-- Name: sikayetler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.sikayetler (
    sikayet_id integer NOT NULL,
    kullanici_id integer,
    sikayet_metni text,
    sikayet_tarihi timestamp without time zone
);


ALTER TABLE public.sikayetler OWNER TO postgres;

--
-- TOC entry 239 (class 1259 OID 16626)
-- Name: sikayetler_sikayet_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.sikayetler_sikayet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.sikayetler_sikayet_id_seq OWNER TO postgres;

--
-- TOC entry 5168 (class 0 OID 0)
-- Dependencies: 239
-- Name: sikayetler_sikayet_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.sikayetler_sikayet_id_seq OWNED BY public.sikayetler.sikayet_id;


--
-- TOC entry 250 (class 1259 OID 16719)
-- Name: trenler; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.trenler (
    tren_id integer NOT NULL,
    vagon_sayisi integer NOT NULL,
    yemekli_vagon boolean DEFAULT false
)
INHERITS (public.araclar);


ALTER TABLE public.trenler OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 16718)
-- Name: trenler_tren_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.trenler_tren_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.trenler_tren_id_seq OWNER TO postgres;

--
-- TOC entry 5169 (class 0 OID 0)
-- Dependencies: 249
-- Name: trenler_tren_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.trenler_tren_id_seq OWNED BY public.trenler.tren_id;


--
-- TOC entry 248 (class 1259 OID 16711)
-- Name: ucaklar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ucaklar (
    ucak_id integer NOT NULL,
    havayolu character varying(100) NOT NULL,
    business_koltuk_sayisi integer NOT NULL,
    ekonomi_koltuk_sayisi integer NOT NULL
)
INHERITS (public.araclar);


ALTER TABLE public.ucaklar OWNER TO postgres;

--
-- TOC entry 247 (class 1259 OID 16710)
-- Name: ucaklar_ucak_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ucaklar_ucak_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.ucaklar_ucak_id_seq OWNER TO postgres;

--
-- TOC entry 5170 (class 0 OID 0)
-- Dependencies: 247
-- Name: ucaklar_ucak_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ucaklar_ucak_id_seq OWNED BY public.ucaklar.ucak_id;


--
-- TOC entry 4867 (class 2604 OID 16492)
-- Name: araclar arac_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.araclar ALTER COLUMN arac_id SET DEFAULT nextval('public.araclar_arac_id_seq'::regclass);


--
-- TOC entry 4877 (class 2604 OID 16613)
-- Name: bagajlar bagaj_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bagajlar ALTER COLUMN bagaj_id SET DEFAULT nextval('public.bagajlar_bagaj_id_seq'::regclass);


--
-- TOC entry 4871 (class 2604 OID 16538)
-- Name: biletler bilet_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler ALTER COLUMN bilet_id SET DEFAULT nextval('public.biletler_bilet_id_seq'::regclass);


--
-- TOC entry 4866 (class 2604 OID 16485)
-- Name: firmalar firma_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.firmalar ALTER COLUMN firma_id SET DEFAULT nextval('public.firmalar_firma_id_seq'::regclass);


--
-- TOC entry 4880 (class 2604 OID 16687)
-- Name: hizmetler hizmet_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hizmetler ALTER COLUMN hizmet_id SET DEFAULT nextval('public.hizmetler_hizmet_id_seq'::regclass);


--
-- TOC entry 4875 (class 2604 OID 16584)
-- Name: indirimler indirim_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.indirimler ALTER COLUMN indirim_id SET DEFAULT nextval('public.indirimler_indirim_id_seq'::regclass);


--
-- TOC entry 4881 (class 2604 OID 16699)
-- Name: islem_loglari log_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islem_loglari ALTER COLUMN log_id SET DEFAULT nextval('public.islem_loglari_log_id_seq'::regclass);


--
-- TOC entry 4892 (class 2604 OID 16784)
-- Name: istasyonlar istasyon_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.istasyonlar ALTER COLUMN istasyon_id SET DEFAULT nextval('public.istasyonlar_istasyon_id_seq'::regclass);


--
-- TOC entry 4874 (class 2604 OID 16572)
-- Name: kampanyalar kampanya_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kampanyalar ALTER COLUMN kampanya_id SET DEFAULT nextval('public.kampanyalar_kampanya_id_seq'::regclass);


--
-- TOC entry 4865 (class 2604 OID 16476)
-- Name: kullanicilar kullanici_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kullanicilar ALTER COLUMN kullanici_id SET DEFAULT nextval('public."kullanıcılar_kullanici_id_seq"'::regclass);


--
-- TOC entry 4876 (class 2604 OID 16601)
-- Name: odemeler odeme_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odemeler ALTER COLUMN odeme_id SET DEFAULT nextval('public.odemeler_odeme_id_seq'::regclass);


--
-- TOC entry 4887 (class 2604 OID 16731)
-- Name: otobusler arac_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.otobusler ALTER COLUMN arac_id SET DEFAULT nextval('public.araclar_arac_id_seq'::regclass);


--
-- TOC entry 4888 (class 2604 OID 16732)
-- Name: otobusler otobus_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.otobusler ALTER COLUMN otobus_id SET DEFAULT nextval('public.otobusler_otobus_id_seq'::regclass);


--
-- TOC entry 4891 (class 2604 OID 16754)
-- Name: personel personel_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel ALTER COLUMN personel_id SET DEFAULT nextval('public.personel_personel_id_seq'::regclass);


--
-- TOC entry 4872 (class 2604 OID 16555)
-- Name: rezervasyonlar rezervasyon_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar ALTER COLUMN rezervasyon_id SET DEFAULT nextval('public.rezervasyonlar_rezervasyon_id_seq'::regclass);


--
-- TOC entry 4879 (class 2604 OID 16644)
-- Name: sefer_durumlari sefer_durumu_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sefer_durumlari ALTER COLUMN sefer_durumu_id SET DEFAULT nextval('public.sefer_durumlari_sefer_durumu_id_seq'::regclass);


--
-- TOC entry 4869 (class 2604 OID 16511)
-- Name: seferler sefer_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seferler ALTER COLUMN sefer_id SET DEFAULT nextval('public.seferler_sefer_id_seq'::regclass);


--
-- TOC entry 4868 (class 2604 OID 16504)
-- Name: sehirler sehir_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sehirler ALTER COLUMN sehir_id SET DEFAULT nextval('public.sehirler_sehir_id_seq'::regclass);


--
-- TOC entry 4878 (class 2604 OID 16630)
-- Name: sikayetler sikayet_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sikayetler ALTER COLUMN sikayet_id SET DEFAULT nextval('public.sikayetler_sikayet_id_seq'::regclass);


--
-- TOC entry 4884 (class 2604 OID 16722)
-- Name: trenler arac_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.trenler ALTER COLUMN arac_id SET DEFAULT nextval('public.araclar_arac_id_seq'::regclass);


--
-- TOC entry 4885 (class 2604 OID 16723)
-- Name: trenler tren_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.trenler ALTER COLUMN tren_id SET DEFAULT nextval('public.trenler_tren_id_seq'::regclass);


--
-- TOC entry 4882 (class 2604 OID 16714)
-- Name: ucaklar arac_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ucaklar ALTER COLUMN arac_id SET DEFAULT nextval('public.araclar_arac_id_seq'::regclass);


--
-- TOC entry 4883 (class 2604 OID 16715)
-- Name: ucaklar ucak_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ucaklar ALTER COLUMN ucak_id SET DEFAULT nextval('public.ucaklar_ucak_id_seq'::regclass);


--
-- TOC entry 5111 (class 0 OID 16489)
-- Dependencies: 222
-- Data for Name: araclar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.araclar (arac_id, tur, kapasite, firma_id) FROM stdin;
1	Uçak	180	1
2	Otobüs	50	2
3	Tren	300	3
4	Otobüs	40	4
11	Uçak	200	1
12	Otobüs	40	2
13	Tren	240	3
\.


--
-- TOC entry 5127 (class 0 OID 16610)
-- Dependencies: 238
-- Data for Name: bagajlar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.bagajlar (bagaj_id, bilet_id, agirlik, boyut, firma_id) FROM stdin;
\.


--
-- TOC entry 5117 (class 0 OID 16535)
-- Dependencies: 228
-- Data for Name: biletler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.biletler (bilet_id, kullanici_id, sefer_id, koltuk_numarasi, fiyat, rezervasyon_id) FROM stdin;
56	6	202	\N	100.00	27
57	17	271	\N	100.00	28
59	6	202	\N	100.00	29
29	8	37	\N	100.00	16
36	8	34	\N	100.00	10
38	9	38	\N	100.00	5
42	6	55	\N	100.00	18
44	6	53	\N	100.00	20
48	13	\N	\N	100.00	23
49	13	103	\N	100.00	24
1	8	3	12B	150.00	5
54	6	53	\N	100.00	20
\.


--
-- TOC entry 5109 (class 0 OID 16482)
-- Dependencies: 220
-- Data for Name: firmalar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.firmalar (firma_id, ad, telefon_numarasi, gmail, adres) FROM stdin;
1	ABC Havayolları	02124567890	abc@havayolu.com	Havaalanı Caddesi No:10 İstanbul
2	XYZ Otobüs	03121234567	xyz@otobus.com	Otogar Mahallesi No:5 Ankara
3	123 Tren	03462223344	123@tren.com	İstasyon Sokak No:1 İzmir
4	KLM Transport	02564567890	klm@transport.com	Taşımacılar Sitesi No:3 Bursa
5	Türk Hava Yolları	02126667777	info@thy.com	İstanbul, Türkiye
6	Metro Turizm	02125558888	info@metroturizm.com	Ankara, Türkiye
7	TCDD	03122111111	info@tcdd.com	İzmir, Türkiye
\.


--
-- TOC entry 5133 (class 0 OID 16684)
-- Dependencies: 244
-- Data for Name: hizmetler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.hizmetler (hizmet_id, ad, ucret, firma_id) FROM stdin;
1	Bagaj Hakkı Artışı	50.00	1
2	Yemek Servisi	25.00	2
3	WiFi Hizmeti	10.00	3
4	Ekstra Koltuk Alanı	100.00	4
\.


--
-- TOC entry 5123 (class 0 OID 16581)
-- Dependencies: 234
-- Data for Name: indirimler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.indirimler (indirim_id, kullanici_id, kampanya_id, gecerlik_durumu) FROM stdin;
1	1	1	t
2	2	2	t
3	3	3	f
4	4	4	t
\.


--
-- TOC entry 5135 (class 0 OID 16696)
-- Dependencies: 246
-- Data for Name: islem_loglari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.islem_loglari (log_id, kullanici_id, islem_turu, islem_tarihi) FROM stdin;
1	1	Bilet Satın Alma	2024-12-14 12:00:00
2	2	Rezervasyon Yapma	2024-12-15 13:30:00
3	3	Şikayet Oluşturma	2024-12-16 14:45:00
4	4	Bilet İptali	2024-12-17 15:00:00
5	1	Bilet Alındı	2024-12-19 00:28:08.529086
6	2	Bilet Alındı	2024-12-19 00:29:50.976504
8	8	Bilet Alındı	2024-12-22 17:35:46.665646
9	8	Bilet Alındı	2024-12-22 17:36:19.800257
10	8	Bilet Alındı	2024-12-22 22:34:12.439387
11	8	Bilet Alındı	2024-12-22 22:57:36.191245
12	8	Bilet Alındı	2024-12-22 22:57:56.904018
13	8	Bilet Alındı	2024-12-22 22:59:48.851156
14	8	Bilet Alındı	2024-12-22 22:59:54.973907
15	8	Bilet Alındı	2024-12-22 23:00:34.604768
16	8	Bilet Alındı	2024-12-22 23:04:32.345573
17	8	Bilet Alındı	2024-12-22 23:04:43.713455
18	8	Bilet Alındı	2024-12-22 23:05:59.588243
19	8	Bilet Alındı	2024-12-22 23:07:38.908241
20	9	Bilet Alındı	2024-12-22 23:33:47.299632
21	9	Bilet Alındı	2024-12-22 23:34:34.758216
22	8	Bilet Alındı	2024-12-22 23:43:04.01084
23	6	Bilet Alındı	2024-12-22 23:46:41.770457
24	6	Bilet Alındı	2024-12-23 02:25:36.858366
25	6	Bilet Alındı	2024-12-23 02:28:10.829075
26	6	Bilet Alındı	2024-12-23 02:29:03.807235
27	11	Bilet Alındı	2024-12-23 03:03:32.694786
28	9	Bilet Alındı	2024-12-23 06:43:57.531728
29	13	Bilet Alındı	2024-12-23 07:15:44.399064
30	13	Bilet Alındı	2024-12-23 07:18:14.73267
31	13	Bilet Alındı	2024-12-23 07:21:13.346778
32	14	Bilet Alındı	2024-12-23 08:10:08.149738
33	8	Bilet Alındı	2024-12-23 16:26:09.450577
34	9	Bilet Alındı	2024-12-23 16:27:58.580985
35	9	Bilet Alındı	2024-12-23 16:29:43.190203
36	8	Şikayet Eklendi	2024-12-23 16:47:48.650469
37	8	Şikayet Eklendi	2024-12-23 17:05:56.411202
38	8	Şikayet Eklendi	2024-12-23 20:29:00.008626
39	6	Bilet Alındı	2024-12-23 20:44:00.485388
40	8	Bilet Alındı	2024-12-23 21:12:03.746169
41	6	Bilet Alındı	2024-12-23 21:14:32.322517
42	17	Bilet Alındı	2024-12-23 21:34:36.658937
43	6	Bilet Alındı	2024-12-23 21:41:42.000513
\.


--
-- TOC entry 5145 (class 0 OID 16781)
-- Dependencies: 256
-- Data for Name: istasyonlar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.istasyonlar (istasyon_id, ad, tur, sehir_id) FROM stdin;
\.


--
-- TOC entry 5121 (class 0 OID 16569)
-- Dependencies: 232
-- Data for Name: kampanyalar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.kampanyalar (kampanya_id, firma_id, aciklama, oran, baslangis_tarihi, bitis_tarihi) FROM stdin;
1	1	Yılbaşı İndirimi	20.00	2024-12-01	2024-12-31
2	2	Otobüs Kampanyası	10.00	2024-12-10	2024-12-20
3	3	Tren Bileti İndirimi	15.00	2024-12-05	2024-12-25
4	4	Kış Sezonu Kampanyası	25.00	2024-12-15	2024-12-30
\.


--
-- TOC entry 5107 (class 0 OID 16473)
-- Dependencies: 218
-- Data for Name: kullanicilar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.kullanicilar (kullanici_id, ad, soy_ad, email, "Kullancici_Sifre", telefon) FROM stdin;
1	Ahmet	Yılmaz	ahmet@example.com	123456	05321234567
2	Ayşe	Kaya	ayse@example.com	654321	05337654321
3	Mehmet	Demir	mehmet@example.com	987654	05319876543
4	Elif	Şahin	elif@example.com	456789	05324567890
5	selim	dew	de	ds	44
6	selim	altın	abd933231@gmail.com	Salam1234	5066710818
7	selim	altın	kesjfbwekj	Salam1234	3543442
8	1	1	1	1	1
9	2	2	2	2	2
10	Kerim	Altın	sdasdasd	1	635353535
11	kkerim	altın	asdadeas	12	2546354
13	abdulselam	almasri	abd933231	123	05066710818
14	3	3	54	3	513
15	wd	sadf	esad	esf	esf
16	dcdsv	c	scs	sc	sc
17	bilal	scad	asdf	12	sacdsd
\.


--
-- TOC entry 5125 (class 0 OID 16598)
-- Dependencies: 236
-- Data for Name: odemeler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.odemeler (odeme_id, bilet_id, odeme_turu, tutar, odeme_tarihi) FROM stdin;
6	29	Kredi kart	100.00	2024-12-22 22:57:36.199654
13	36	Kredi kart	100.00	2024-12-22 23:05:59.593359
15	38	Kredi kart	100.00	2024-12-22 23:33:47.305163
19	42	Kredi kart	100.00	2024-12-23 02:25:36.865242
21	44	Kredi kart	100.00	2024-12-23 02:29:03.810426
25	48	Kredi kart	100.00	2024-12-23 07:18:14.738395
26	49	Kredi kart	100.00	2024-12-23 07:21:13.351377
31	56	Kredi kart	100.00	2024-12-23 21:14:32.328901
32	57	Kredi kart	100.00	2024-12-23 21:34:36.676136
33	59	Kredi kart	100.00	2024-12-23 21:41:42.008095
\.


--
-- TOC entry 5141 (class 0 OID 16728)
-- Dependencies: 252
-- Data for Name: otobusler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.otobusler (arac_id, tur, kapasite, firma_id, otobus_id, katlar, wifi) FROM stdin;
9	Otobüs	50	2	1	2	t
10	Otobüs	40	4	2	1	f
2	\N	\N	\N	3	1	t
2	\N	\N	\N	4	2	f
\.


--
-- TOC entry 5143 (class 0 OID 16751)
-- Dependencies: 254
-- Data for Name: personel; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.personel (personel_id, ad, soy_ad, arac_id, gorev_turu, firma_id) FROM stdin;
1	selim	Yıldız	1	Pilot	1
2	kerim	Kara	2	Şoför	2
3	selin	Demir	3	Makinist	3
4	sait	Çelik	4	Şoför	4
\.


--
-- TOC entry 5119 (class 0 OID 16552)
-- Dependencies: 230
-- Data for Name: rezervasyonlar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.rezervasyonlar (rezervasyon_id, kullanici_id, sefer_id, durum, rezervasyon_tarihi) FROM stdin;
8	8	42	Ödendi	2024-12-22 17:54:13.751916
9	8	38	Ödendi	2024-12-22 18:39:12.703902
2	8	34	Ödendi	2024-12-22 01:04:14.259155
14	8	46	ödendi	2024-12-22 20:11:31.023481
16	8	37	ödendi	2024-12-22 22:57:05.880606
12	8	37	ödendi	2024-12-22 19:14:23.803222
4	8	37	ödendi	2024-12-22 01:16:49.823157
10	8	34	Ödendi	2024-12-22 18:40:56.148269
3	8	36	Ödendi	2024-12-22 01:05:59.612163
5	9	38	Ödendi	2024-12-22 01:20:56.982886
17	9	35	Ödendi	2024-12-22 23:34:07.913517
15	8	38	Ödendi	2024-12-22 21:47:14.37393
7	6	37	Ödendi	2024-12-22 02:24:21.146674
18	6	44	Ödendi	2024-12-23 02:25:18.66918
19	6	53	Ödendi	2024-12-23 02:28:02.348438
21	11	48	Ödendi	2024-12-23 03:03:22.123434
6	9	45	Ödendi	2024-12-22 01:22:17.975325
22	13	50	Ödendi	2024-12-23 07:15:24.558826
23	13	61	Ödendi	2024-12-23 07:17:56.186312
24	13	98	Ödendi	2024-12-23 07:21:07.43698
25	14	52	Ödendi	2024-12-23 08:10:02.667653
13	9	38	Ödendi	2024-12-22 20:00:09.381709
11	9	38	Ödendi	2024-12-22 19:10:29.059127
20	6	53	Ödendi	2024-12-23 02:28:44.604171
26	8	53	Ödendi	2024-12-23 19:33:10.88432
27	6	202	Ödendi	2024-12-23 21:14:20.633108
28	17	274	Ödendi	2024-12-23 21:34:21.719998
29	6	202	Ödendi	2024-12-23 21:40:34.629042
\.


--
-- TOC entry 5131 (class 0 OID 16641)
-- Dependencies: 242
-- Data for Name: sefer_durumlari; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sefer_durumlari (sefer_durumu_id, sefer_id, durum, aciklama) FROM stdin;
1	124	Planlandı	Yeni sefer planlandı.
2	125	Planlandı	Yeni sefer planlandı.
3	126	Planlandı	Yeni sefer planlandı.
4	127	Planlandı	Yeni sefer planlandı.
5	128	Planlandı	Yeni sefer planlandı.
6	129	Planlandı	Yeni sefer planlandı.
7	130	Planlandı	Yeni sefer planlandı.
8	131	Planlandı	Yeni sefer planlandı.
9	132	Planlandı	Yeni sefer planlandı.
10	133	Planlandı	Yeni sefer planlandı.
11	134	Planlandı	Yeni sefer planlandı.
12	135	Planlandı	Yeni sefer planlandı.
13	136	Planlandı	Yeni sefer planlandı.
14	137	Planlandı	Yeni sefer planlandı.
15	138	Planlandı	Yeni sefer planlandı.
16	139	Planlandı	Yeni sefer planlandı.
17	140	Planlandı	Yeni sefer planlandı.
18	141	Planlandı	Yeni sefer planlandı.
19	142	Planlandı	Yeni sefer planlandı.
20	143	Planlandı	Yeni sefer planlandı.
21	144	Planlandı	Yeni sefer planlandı.
22	145	Planlandı	Yeni sefer planlandı.
23	146	Planlandı	Yeni sefer planlandı.
24	147	Planlandı	Yeni sefer planlandı.
25	148	Planlandı	Yeni sefer planlandı.
26	149	Planlandı	Yeni sefer planlandı.
27	150	Planlandı	Yeni sefer planlandı.
28	151	Planlandı	Yeni sefer planlandı.
29	152	Planlandı	Yeni sefer planlandı.
30	153	Planlandı	Yeni sefer planlandı.
31	154	Planlandı	Yeni sefer planlandı.
32	155	Planlandı	Yeni sefer planlandı.
33	156	Planlandı	Yeni sefer planlandı.
34	157	Planlandı	Yeni sefer planlandı.
35	158	Planlandı	Yeni sefer planlandı.
36	159	Planlandı	Yeni sefer planlandı.
37	160	Planlandı	Yeni sefer planlandı.
38	161	Planlandı	Yeni sefer planlandı.
39	162	Planlandı	Yeni sefer planlandı.
40	163	Planlandı	Yeni sefer planlandı.
41	164	Planlandı	Yeni sefer planlandı.
42	165	Planlandı	Yeni sefer planlandı.
43	166	Planlandı	Yeni sefer planlandı.
44	167	Planlandı	Yeni sefer planlandı.
45	168	Planlandı	Yeni sefer planlandı.
46	169	Planlandı	Yeni sefer planlandı.
47	170	Planlandı	Yeni sefer planlandı.
48	171	Planlandı	Yeni sefer planlandı.
49	172	Planlandı	Yeni sefer planlandı.
50	173	Planlandı	Yeni sefer planlandı.
51	174	Planlandı	Yeni sefer planlandı.
52	175	Planlandı	Yeni sefer planlandı.
53	176	Planlandı	Yeni sefer planlandı.
54	177	Planlandı	Yeni sefer planlandı.
55	178	Planlandı	Yeni sefer planlandı.
56	179	Planlandı	Yeni sefer planlandı.
57	180	Planlandı	Yeni sefer planlandı.
58	181	Planlandı	Yeni sefer planlandı.
59	182	Planlandı	Yeni sefer planlandı.
60	183	Planlandı	Yeni sefer planlandı.
61	184	Planlandı	Yeni sefer planlandı.
62	185	Planlandı	Yeni sefer planlandı.
63	186	Planlandı	Yeni sefer planlandı.
64	187	Planlandı	Yeni sefer planlandı.
65	188	Planlandı	Yeni sefer planlandı.
66	189	Planlandı	Yeni sefer planlandı.
67	190	Planlandı	Yeni sefer planlandı.
68	191	Planlandı	Yeni sefer planlandı.
69	192	Planlandı	Yeni sefer planlandı.
70	193	Planlandı	Yeni sefer planlandı.
71	194	Planlandı	Yeni sefer planlandı.
72	195	Planlandı	Yeni sefer planlandı.
73	196	Planlandı	Yeni sefer planlandı.
74	197	Planlandı	Yeni sefer planlandı.
75	198	Planlandı	Yeni sefer planlandı.
76	199	Planlandı	Yeni sefer planlandı.
77	200	Planlandı	Yeni sefer planlandı.
78	201	Planlandı	Yeni sefer planlandı.
79	202	Planlandı	Yeni sefer planlandı.
80	203	Planlandı	Yeni sefer planlandı.
81	204	Planlandı	Yeni sefer planlandı.
82	205	Planlandı	Yeni sefer planlandı.
83	206	Planlandı	Yeni sefer planlandı.
84	207	Planlandı	Yeni sefer planlandı.
85	208	Planlandı	Yeni sefer planlandı.
86	209	Planlandı	Yeni sefer planlandı.
87	210	Planlandı	Yeni sefer planlandı.
88	211	Planlandı	Yeni sefer planlandı.
89	212	Planlandı	Yeni sefer planlandı.
90	213	Planlandı	Yeni sefer planlandı.
91	214	Planlandı	Yeni sefer planlandı.
92	215	Planlandı	Yeni sefer planlandı.
93	216	Planlandı	Yeni sefer planlandı.
94	217	Planlandı	Yeni sefer planlandı.
95	218	Planlandı	Yeni sefer planlandı.
96	219	Planlandı	Yeni sefer planlandı.
97	220	Planlandı	Yeni sefer planlandı.
98	221	Planlandı	Yeni sefer planlandı.
99	222	Planlandı	Yeni sefer planlandı.
100	223	Planlandı	Yeni sefer planlandı.
101	224	Planlandı	Yeni sefer planlandı.
102	225	Planlandı	Yeni sefer planlandı.
103	226	Planlandı	Yeni sefer planlandı.
104	227	Planlandı	Yeni sefer planlandı.
105	228	Planlandı	Yeni sefer planlandı.
106	229	Planlandı	Yeni sefer planlandı.
107	230	Planlandı	Yeni sefer planlandı.
108	231	Planlandı	Yeni sefer planlandı.
109	232	Planlandı	Yeni sefer planlandı.
110	233	Planlandı	Yeni sefer planlandı.
111	234	Planlandı	Yeni sefer planlandı.
112	235	Planlandı	Yeni sefer planlandı.
113	236	Planlandı	Yeni sefer planlandı.
114	237	Planlandı	Yeni sefer planlandı.
115	238	Planlandı	Yeni sefer planlandı.
116	239	Planlandı	Yeni sefer planlandı.
117	240	Planlandı	Yeni sefer planlandı.
118	241	Planlandı	Yeni sefer planlandı.
119	242	Planlandı	Yeni sefer planlandı.
120	243	Planlandı	Yeni sefer planlandı.
121	244	Planlandı	Yeni sefer planlandı.
122	245	Planlandı	Yeni sefer planlandı.
123	246	Planlandı	Yeni sefer planlandı.
124	247	Planlandı	Yeni sefer planlandı.
125	248	Planlandı	Yeni sefer planlandı.
126	249	Planlandı	Yeni sefer planlandı.
127	250	Planlandı	Yeni sefer planlandı.
128	251	Planlandı	Yeni sefer planlandı.
129	252	Planlandı	Yeni sefer planlandı.
130	253	Planlandı	Yeni sefer planlandı.
131	254	Planlandı	Yeni sefer planlandı.
132	255	Planlandı	Yeni sefer planlandı.
133	256	Planlandı	Yeni sefer planlandı.
134	257	Planlandı	Yeni sefer planlandı.
135	258	Planlandı	Yeni sefer planlandı.
136	259	Planlandı	Yeni sefer planlandı.
137	260	Planlandı	Yeni sefer planlandı.
138	261	Planlandı	Yeni sefer planlandı.
139	262	Planlandı	Yeni sefer planlandı.
140	263	Planlandı	Yeni sefer planlandı.
141	264	Planlandı	Yeni sefer planlandı.
142	265	Planlandı	Yeni sefer planlandı.
143	266	Planlandı	Yeni sefer planlandı.
144	267	Planlandı	Yeni sefer planlandı.
145	268	Planlandı	Yeni sefer planlandı.
146	269	Planlandı	Yeni sefer planlandı.
147	270	Planlandı	Yeni sefer planlandı.
148	271	Planlandı	Yeni sefer planlandı.
149	272	Planlandı	Yeni sefer planlandı.
150	273	Planlandı	Yeni sefer planlandı.
151	274	Planlandı	Yeni sefer planlandı.
152	275	Planlandı	Yeni sefer planlandı.
153	276	Planlandı	Yeni sefer planlandı.
154	277	Planlandı	Yeni sefer planlandı.
155	278	Planlandı	Yeni sefer planlandı.
156	279	Planlandı	Yeni sefer planlandı.
157	280	Planlandı	Yeni sefer planlandı.
158	281	Planlandı	Yeni sefer planlandı.
159	282	Planlandı	Yeni sefer planlandı.
160	283	Planlandı	Yeni sefer planlandı.
161	284	Planlandı	Yeni sefer planlandı.
162	285	Planlandı	Yeni sefer planlandı.
163	286	Planlandı	Yeni sefer planlandı.
164	287	Planlandı	Yeni sefer planlandı.
165	288	Planlandı	Yeni sefer planlandı.
166	289	Planlandı	Yeni sefer planlandı.
167	290	Planlandı	Yeni sefer planlandı.
168	291	Planlandı	Yeni sefer planlandı.
169	292	Planlandı	Yeni sefer planlandı.
170	293	Planlandı	Yeni sefer planlandı.
171	294	Planlandı	Yeni sefer planlandı.
172	295	Planlandı	Yeni sefer planlandı.
173	296	Planlandı	Yeni sefer planlandı.
174	297	Planlandı	Yeni sefer planlandı.
175	298	Planlandı	Yeni sefer planlandı.
176	299	Planlandı	Yeni sefer planlandı.
177	300	Planlandı	Yeni sefer planlandı.
178	301	Planlandı	Yeni sefer planlandı.
179	302	Planlandı	Yeni sefer planlandı.
180	303	Planlandı	Yeni sefer planlandı.
181	304	Planlandı	Yeni sefer planlandı.
182	305	Planlandı	Yeni sefer planlandı.
183	306	Planlandı	Yeni sefer planlandı.
184	307	Planlandı	Yeni sefer planlandı.
185	308	Planlandı	Yeni sefer planlandı.
186	309	Planlandı	Yeni sefer planlandı.
187	310	Planlandı	Yeni sefer planlandı.
188	311	Planlandı	Yeni sefer planlandı.
189	312	Planlandı	Yeni sefer planlandı.
190	313	Planlandı	Yeni sefer planlandı.
191	314	Planlandı	Yeni sefer planlandı.
192	315	Planlandı	Yeni sefer planlandı.
193	316	Planlandı	Yeni sefer planlandı.
194	317	Planlandı	Yeni sefer planlandı.
195	318	Planlandı	Yeni sefer planlandı.
196	319	Planlandı	Yeni sefer planlandı.
197	320	Planlandı	Yeni sefer planlandı.
198	321	Planlandı	Yeni sefer planlandı.
199	322	Planlandı	Yeni sefer planlandı.
200	323	Planlandı	Yeni sefer planlandı.
201	324	Planlandı	Yeni sefer planlandı.
202	325	Planlandı	Yeni sefer planlandı.
203	326	Planlandı	Yeni sefer planlandı.
204	327	Planlandı	Yeni sefer planlandı.
205	328	Planlandı	Yeni sefer planlandı.
206	329	Planlandı	Yeni sefer planlandı.
207	330	Planlandı	Yeni sefer planlandı.
208	331	Planlandı	Yeni sefer planlandı.
209	332	Planlandı	Yeni sefer planlandı.
210	333	Planlandı	Yeni sefer planlandı.
211	334	Planlandı	Yeni sefer planlandı.
212	335	Planlandı	Yeni sefer planlandı.
213	336	Planlandı	Yeni sefer planlandı.
214	337	Planlandı	Yeni sefer planlandı.
215	338	Planlandı	Yeni sefer planlandı.
216	339	Planlandı	Yeni sefer planlandı.
217	340	Planlandı	Yeni sefer planlandı.
218	341	Planlandı	Yeni sefer planlandı.
219	342	Planlandı	Yeni sefer planlandı.
220	343	Planlandı	Yeni sefer planlandı.
221	344	Planlandı	Yeni sefer planlandı.
222	345	Planlandı	Yeni sefer planlandı.
223	346	Planlandı	Yeni sefer planlandı.
224	347	Planlandı	Yeni sefer planlandı.
225	348	Planlandı	Yeni sefer planlandı.
226	349	Planlandı	Yeni sefer planlandı.
227	350	Planlandı	Yeni sefer planlandı.
228	351	Planlandı	Yeni sefer planlandı.
229	352	Planlandı	Yeni sefer planlandı.
230	353	Planlandı	Yeni sefer planlandı.
231	354	Planlandı	Yeni sefer planlandı.
232	355	Planlandı	Yeni sefer planlandı.
233	356	Planlandı	Yeni sefer planlandı.
234	357	Planlandı	Yeni sefer planlandı.
235	358	Planlandı	Yeni sefer planlandı.
236	359	Planlandı	Yeni sefer planlandı.
237	360	Planlandı	Yeni sefer planlandı.
238	361	Planlandı	Yeni sefer planlandı.
239	362	Planlandı	Yeni sefer planlandı.
240	363	Planlandı	Yeni sefer planlandı.
241	364	Planlandı	Yeni sefer planlandı.
242	365	Planlandı	Yeni sefer planlandı.
243	366	Planlandı	Yeni sefer planlandı.
244	367	Planlandı	Yeni sefer planlandı.
245	368	Planlandı	Yeni sefer planlandı.
246	369	Planlandı	Yeni sefer planlandı.
247	370	Planlandı	Yeni sefer planlandı.
248	371	Planlandı	Yeni sefer planlandı.
249	372	Planlandı	Yeni sefer planlandı.
250	373	Planlandı	Yeni sefer planlandı.
251	374	Planlandı	Yeni sefer planlandı.
252	375	Planlandı	Yeni sefer planlandı.
253	376	Planlandı	Yeni sefer planlandı.
254	377	Planlandı	Yeni sefer planlandı.
255	378	Planlandı	Yeni sefer planlandı.
256	379	Planlandı	Yeni sefer planlandı.
257	380	Planlandı	Yeni sefer planlandı.
258	381	Planlandı	Yeni sefer planlandı.
259	382	Planlandı	Yeni sefer planlandı.
260	383	Planlandı	Yeni sefer planlandı.
261	384	Planlandı	Yeni sefer planlandı.
262	385	Planlandı	Yeni sefer planlandı.
263	386	Planlandı	Yeni sefer planlandı.
264	387	Planlandı	Yeni sefer planlandı.
265	388	Planlandı	Yeni sefer planlandı.
266	389	Planlandı	Yeni sefer planlandı.
267	390	Planlandı	Yeni sefer planlandı.
268	391	Planlandı	Yeni sefer planlandı.
269	392	Planlandı	Yeni sefer planlandı.
270	393	Planlandı	Yeni sefer planlandı.
271	394	Planlandı	Yeni sefer planlandı.
272	395	Planlandı	Yeni sefer planlandı.
273	396	Planlandı	Yeni sefer planlandı.
274	397	Planlandı	Yeni sefer planlandı.
275	398	Planlandı	Yeni sefer planlandı.
276	399	Planlandı	Yeni sefer planlandı.
277	400	Planlandı	Yeni sefer planlandı.
278	401	Planlandı	Yeni sefer planlandı.
279	402	Planlandı	Yeni sefer planlandı.
280	403	Planlandı	Yeni sefer planlandı.
281	404	Planlandı	Yeni sefer planlandı.
282	405	Planlandı	Yeni sefer planlandı.
283	406	Planlandı	Yeni sefer planlandı.
284	407	Planlandı	Yeni sefer planlandı.
285	408	Planlandı	Yeni sefer planlandı.
286	409	Planlandı	Yeni sefer planlandı.
287	410	Planlandı	Yeni sefer planlandı.
288	411	Planlandı	Yeni sefer planlandı.
289	412	Planlandı	Yeni sefer planlandı.
290	413	Planlandı	Yeni sefer planlandı.
291	414	Planlandı	Yeni sefer planlandı.
292	415	Planlandı	Yeni sefer planlandı.
293	416	Planlandı	Yeni sefer planlandı.
294	417	Planlandı	Yeni sefer planlandı.
295	418	Planlandı	Yeni sefer planlandı.
296	419	Planlandı	Yeni sefer planlandı.
297	420	Planlandı	Yeni sefer planlandı.
298	421	Planlandı	Yeni sefer planlandı.
299	422	Planlandı	Yeni sefer planlandı.
300	423	Planlandı	Yeni sefer planlandı.
301	424	Planlandı	Yeni sefer planlandı.
302	425	Planlandı	Yeni sefer planlandı.
303	426	Planlandı	Yeni sefer planlandı.
304	427	Planlandı	Yeni sefer planlandı.
305	428	Planlandı	Yeni sefer planlandı.
306	429	Planlandı	Yeni sefer planlandı.
307	430	Planlandı	Yeni sefer planlandı.
308	431	Planlandı	Yeni sefer planlandı.
309	432	Planlandı	Yeni sefer planlandı.
310	433	Planlandı	Yeni sefer planlandı.
311	434	Planlandı	Yeni sefer planlandı.
312	435	Planlandı	Yeni sefer planlandı.
313	436	Planlandı	Yeni sefer planlandı.
314	437	Planlandı	Yeni sefer planlandı.
315	438	Planlandı	Yeni sefer planlandı.
316	439	Planlandı	Yeni sefer planlandı.
317	440	Planlandı	Yeni sefer planlandı.
318	441	Planlandı	Yeni sefer planlandı.
319	442	Planlandı	Yeni sefer planlandı.
320	443	Planlandı	Yeni sefer planlandı.
321	444	Planlandı	Yeni sefer planlandı.
322	445	Planlandı	Yeni sefer planlandı.
323	446	Planlandı	Yeni sefer planlandı.
324	447	Planlandı	Yeni sefer planlandı.
325	448	Planlandı	Yeni sefer planlandı.
326	449	Planlandı	Yeni sefer planlandı.
327	450	Planlandı	Yeni sefer planlandı.
328	451	Planlandı	Yeni sefer planlandı.
329	452	Planlandı	Yeni sefer planlandı.
330	453	Planlandı	Yeni sefer planlandı.
331	454	Planlandı	Yeni sefer planlandı.
332	455	Planlandı	Yeni sefer planlandı.
333	456	Planlandı	Yeni sefer planlandı.
334	457	Planlandı	Yeni sefer planlandı.
335	458	Planlandı	Yeni sefer planlandı.
336	459	Planlandı	Yeni sefer planlandı.
337	460	Planlandı	Yeni sefer planlandı.
338	461	Planlandı	Yeni sefer planlandı.
339	462	Planlandı	Yeni sefer planlandı.
340	463	Planlandı	Yeni sefer planlandı.
341	464	Planlandı	Yeni sefer planlandı.
342	465	Planlandı	Yeni sefer planlandı.
343	466	Planlandı	Yeni sefer planlandı.
344	467	Planlandı	Yeni sefer planlandı.
345	468	Planlandı	Yeni sefer planlandı.
346	469	Planlandı	Yeni sefer planlandı.
347	470	Planlandı	Yeni sefer planlandı.
348	471	Planlandı	Yeni sefer planlandı.
349	472	Planlandı	Yeni sefer planlandı.
350	473	Planlandı	Yeni sefer planlandı.
351	474	Planlandı	Yeni sefer planlandı.
352	475	Planlandı	Yeni sefer planlandı.
353	476	Planlandı	Yeni sefer planlandı.
354	477	Planlandı	Yeni sefer planlandı.
355	478	Planlandı	Yeni sefer planlandı.
356	479	Planlandı	Yeni sefer planlandı.
357	480	Planlandı	Yeni sefer planlandı.
358	481	Planlandı	Yeni sefer planlandı.
359	482	Planlandı	Yeni sefer planlandı.
360	483	Planlandı	Yeni sefer planlandı.
361	484	Planlandı	Yeni sefer planlandı.
362	485	Planlandı	Yeni sefer planlandı.
363	486	Planlandı	Yeni sefer planlandı.
364	487	Planlandı	Yeni sefer planlandı.
365	488	Planlandı	Yeni sefer planlandı.
366	489	Planlandı	Yeni sefer planlandı.
367	490	Planlandı	Yeni sefer planlandı.
368	491	Planlandı	Yeni sefer planlandı.
369	492	Planlandı	Yeni sefer planlandı.
370	493	Planlandı	Yeni sefer planlandı.
371	494	Planlandı	Yeni sefer planlandı.
372	495	Planlandı	Yeni sefer planlandı.
373	496	Planlandı	Yeni sefer planlandı.
374	497	Planlandı	Yeni sefer planlandı.
375	498	Planlandı	Yeni sefer planlandı.
376	499	Planlandı	Yeni sefer planlandı.
377	500	Planlandı	Yeni sefer planlandı.
378	501	Planlandı	Yeni sefer planlandı.
379	502	Planlandı	Yeni sefer planlandı.
380	503	Planlandı	Yeni sefer planlandı.
381	504	Planlandı	Yeni sefer planlandı.
382	505	Planlandı	Yeni sefer planlandı.
383	506	Planlandı	Yeni sefer planlandı.
384	507	Planlandı	Yeni sefer planlandı.
385	508	Planlandı	Yeni sefer planlandı.
386	509	Planlandı	Yeni sefer planlandı.
387	510	Planlandı	Yeni sefer planlandı.
388	511	Planlandı	Yeni sefer planlandı.
389	512	Planlandı	Yeni sefer planlandı.
390	513	Planlandı	Yeni sefer planlandı.
391	514	Planlandı	Yeni sefer planlandı.
392	515	Planlandı	Yeni sefer planlandı.
393	516	Planlandı	Yeni sefer planlandı.
394	517	Planlandı	Yeni sefer planlandı.
395	518	Planlandı	Yeni sefer planlandı.
396	519	Planlandı	Yeni sefer planlandı.
397	520	Planlandı	Yeni sefer planlandı.
398	521	Planlandı	Yeni sefer planlandı.
399	522	Planlandı	Yeni sefer planlandı.
400	523	Planlandı	Yeni sefer planlandı.
401	524	Planlandı	Yeni sefer planlandı.
402	525	Planlandı	Yeni sefer planlandı.
403	526	Planlandı	Yeni sefer planlandı.
404	527	Planlandı	Yeni sefer planlandı.
405	528	Planlandı	Yeni sefer planlandı.
406	529	Planlandı	Yeni sefer planlandı.
407	530	Planlandı	Yeni sefer planlandı.
408	531	Planlandı	Yeni sefer planlandı.
409	532	Planlandı	Yeni sefer planlandı.
410	533	Planlandı	Yeni sefer planlandı.
411	534	Planlandı	Yeni sefer planlandı.
412	535	Planlandı	Yeni sefer planlandı.
413	536	Planlandı	Yeni sefer planlandı.
414	537	Planlandı	Yeni sefer planlandı.
415	538	Planlandı	Yeni sefer planlandı.
416	539	Planlandı	Yeni sefer planlandı.
417	540	Planlandı	Yeni sefer planlandı.
418	541	Planlandı	Yeni sefer planlandı.
419	542	Planlandı	Yeni sefer planlandı.
420	543	Planlandı	Yeni sefer planlandı.
421	544	Planlandı	Yeni sefer planlandı.
422	545	Planlandı	Yeni sefer planlandı.
423	546	Planlandı	Yeni sefer planlandı.
424	547	Planlandı	Yeni sefer planlandı.
425	548	Planlandı	Yeni sefer planlandı.
426	549	Planlandı	Yeni sefer planlandı.
427	550	Planlandı	Yeni sefer planlandı.
428	551	Planlandı	Yeni sefer planlandı.
429	552	Planlandı	Yeni sefer planlandı.
430	553	Planlandı	Yeni sefer planlandı.
431	554	Planlandı	Yeni sefer planlandı.
432	555	Planlandı	Yeni sefer planlandı.
433	556	Planlandı	Yeni sefer planlandı.
434	557	Planlandı	Yeni sefer planlandı.
435	558	Planlandı	Yeni sefer planlandı.
436	559	Planlandı	Yeni sefer planlandı.
437	560	Planlandı	Yeni sefer planlandı.
438	561	Planlandı	Yeni sefer planlandı.
439	562	Planlandı	Yeni sefer planlandı.
440	563	Planlandı	Yeni sefer planlandı.
441	564	Planlandı	Yeni sefer planlandı.
442	565	Planlandı	Yeni sefer planlandı.
443	566	Planlandı	Yeni sefer planlandı.
444	567	Planlandı	Yeni sefer planlandı.
445	568	Planlandı	Yeni sefer planlandı.
446	569	Planlandı	Yeni sefer planlandı.
447	570	Planlandı	Yeni sefer planlandı.
448	571	Planlandı	Yeni sefer planlandı.
449	572	Planlandı	Yeni sefer planlandı.
450	573	Planlandı	Yeni sefer planlandı.
451	574	Planlandı	Yeni sefer planlandı.
452	575	Planlandı	Yeni sefer planlandı.
453	576	Planlandı	Yeni sefer planlandı.
454	577	Planlandı	Yeni sefer planlandı.
455	578	Planlandı	Yeni sefer planlandı.
456	579	Planlandı	Yeni sefer planlandı.
457	580	Planlandı	Yeni sefer planlandı.
458	581	Planlandı	Yeni sefer planlandı.
459	582	Planlandı	Yeni sefer planlandı.
460	583	Planlandı	Yeni sefer planlandı.
461	584	Planlandı	Yeni sefer planlandı.
462	585	Planlandı	Yeni sefer planlandı.
463	586	Planlandı	Yeni sefer planlandı.
464	587	Planlandı	Yeni sefer planlandı.
465	588	Planlandı	Yeni sefer planlandı.
466	589	Planlandı	Yeni sefer planlandı.
467	590	Planlandı	Yeni sefer planlandı.
468	591	Planlandı	Yeni sefer planlandı.
469	592	Planlandı	Yeni sefer planlandı.
470	593	Planlandı	Yeni sefer planlandı.
471	594	Planlandı	Yeni sefer planlandı.
472	595	Planlandı	Yeni sefer planlandı.
473	596	Planlandı	Yeni sefer planlandı.
474	597	Planlandı	Yeni sefer planlandı.
475	598	Planlandı	Yeni sefer planlandı.
476	599	Planlandı	Yeni sefer planlandı.
477	600	Planlandı	Yeni sefer planlandı.
478	601	Planlandı	Yeni sefer planlandı.
479	602	Planlandı	Yeni sefer planlandı.
480	603	Planlandı	Yeni sefer planlandı.
481	604	Planlandı	Yeni sefer planlandı.
482	605	Planlandı	Yeni sefer planlandı.
483	606	Planlandı	Yeni sefer planlandı.
484	607	Planlandı	Yeni sefer planlandı.
485	608	Planlandı	Yeni sefer planlandı.
486	609	Planlandı	Yeni sefer planlandı.
487	610	Planlandı	Yeni sefer planlandı.
488	611	Planlandı	Yeni sefer planlandı.
489	612	Planlandı	Yeni sefer planlandı.
490	613	Planlandı	Yeni sefer planlandı.
491	614	Planlandı	Yeni sefer planlandı.
492	615	Planlandı	Yeni sefer planlandı.
493	616	Planlandı	Yeni sefer planlandı.
494	617	Planlandı	Yeni sefer planlandı.
495	618	Planlandı	Yeni sefer planlandı.
496	619	Planlandı	Yeni sefer planlandı.
497	620	Planlandı	Yeni sefer planlandı.
498	621	Planlandı	Yeni sefer planlandı.
499	622	Planlandı	Yeni sefer planlandı.
500	623	Planlandı	Yeni sefer planlandı.
501	624	Planlandı	Yeni sefer planlandı.
502	625	Planlandı	Yeni sefer planlandı.
503	626	Planlandı	Yeni sefer planlandı.
504	627	Planlandı	Yeni sefer planlandı.
505	628	Planlandı	Yeni sefer planlandı.
506	629	Planlandı	Yeni sefer planlandı.
507	630	Planlandı	Yeni sefer planlandı.
508	631	Planlandı	Yeni sefer planlandı.
509	632	Planlandı	Yeni sefer planlandı.
510	633	Planlandı	Yeni sefer planlandı.
511	634	Planlandı	Yeni sefer planlandı.
512	635	Planlandı	Yeni sefer planlandı.
513	636	Planlandı	Yeni sefer planlandı.
514	637	Planlandı	Yeni sefer planlandı.
515	638	Planlandı	Yeni sefer planlandı.
516	639	Planlandı	Yeni sefer planlandı.
517	640	Planlandı	Yeni sefer planlandı.
518	641	Planlandı	Yeni sefer planlandı.
519	642	Planlandı	Yeni sefer planlandı.
520	643	Planlandı	Yeni sefer planlandı.
521	644	Planlandı	Yeni sefer planlandı.
522	645	Planlandı	Yeni sefer planlandı.
523	646	Planlandı	Yeni sefer planlandı.
524	647	Planlandı	Yeni sefer planlandı.
525	648	Planlandı	Yeni sefer planlandı.
526	649	Planlandı	Yeni sefer planlandı.
527	650	Planlandı	Yeni sefer planlandı.
528	651	Planlandı	Yeni sefer planlandı.
529	652	Planlandı	Yeni sefer planlandı.
530	653	Planlandı	Yeni sefer planlandı.
531	654	Planlandı	Yeni sefer planlandı.
532	655	Planlandı	Yeni sefer planlandı.
533	656	Planlandı	Yeni sefer planlandı.
534	657	Planlandı	Yeni sefer planlandı.
535	658	Planlandı	Yeni sefer planlandı.
536	659	Planlandı	Yeni sefer planlandı.
537	660	Planlandı	Yeni sefer planlandı.
538	661	Planlandı	Yeni sefer planlandı.
539	662	Planlandı	Yeni sefer planlandı.
540	663	Planlandı	Yeni sefer planlandı.
541	664	Planlandı	Yeni sefer planlandı.
542	665	Planlandı	Yeni sefer planlandı.
543	666	Planlandı	Yeni sefer planlandı.
544	667	Planlandı	Yeni sefer planlandı.
545	668	Planlandı	Yeni sefer planlandı.
546	669	Planlandı	Yeni sefer planlandı.
547	670	Planlandı	Yeni sefer planlandı.
548	671	Planlandı	Yeni sefer planlandı.
549	672	Planlandı	Yeni sefer planlandı.
550	673	Planlandı	Yeni sefer planlandı.
551	674	Planlandı	Yeni sefer planlandı.
552	675	Planlandı	Yeni sefer planlandı.
553	676	Planlandı	Yeni sefer planlandı.
554	677	Planlandı	Yeni sefer planlandı.
555	678	Planlandı	Yeni sefer planlandı.
556	679	Planlandı	Yeni sefer planlandı.
557	680	Planlandı	Yeni sefer planlandı.
558	681	Planlandı	Yeni sefer planlandı.
559	682	Planlandı	Yeni sefer planlandı.
560	683	Planlandı	Yeni sefer planlandı.
561	684	Planlandı	Yeni sefer planlandı.
562	685	Planlandı	Yeni sefer planlandı.
563	686	Planlandı	Yeni sefer planlandı.
564	687	Planlandı	Yeni sefer planlandı.
565	688	Planlandı	Yeni sefer planlandı.
566	689	Planlandı	Yeni sefer planlandı.
567	690	Planlandı	Yeni sefer planlandı.
568	691	Planlandı	Yeni sefer planlandı.
569	692	Planlandı	Yeni sefer planlandı.
570	693	Planlandı	Yeni sefer planlandı.
571	694	Planlandı	Yeni sefer planlandı.
572	695	Planlandı	Yeni sefer planlandı.
573	696	Planlandı	Yeni sefer planlandı.
574	697	Planlandı	Yeni sefer planlandı.
575	698	Planlandı	Yeni sefer planlandı.
576	699	Planlandı	Yeni sefer planlandı.
577	700	Planlandı	Yeni sefer planlandı.
578	3	Planlandı	Yeni sefer planlandı.
579	701	Planlandı	Yeni sefer planlandı.
580	1000	Planlandı	Yeni sefer planlandı.
\.


--
-- TOC entry 5115 (class 0 OID 16508)
-- Dependencies: 226
-- Data for Name: seferler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.seferler (sefer_id, arac_id, kalkis_sehir_id, varis_sehir_id, firma_id, tarih, saat, seyahatturu) FROM stdin;
21	1	34	6	1	2024-12-25	08:30:00	Otobüs
22	2	6	35	2	2024-12-26	14:00:00	Otobüs
23	1	34	6	1	2024-12-25	10:30:00	Otobüs
24	2	6	34	2	2024-12-26	15:45:00	Otobüs
25	3	1	5	3	2024-12-27	08:00:00	Otobüs
26	1	34	1	1	2024-12-28	12:15:00	Otobüs
27	3	34	6	3	2024-12-21	09:00:00	Otobüs
28	2	6	34	3	2024-12-21	12:00:00	Otobüs
29	2	1	34	3	2024-12-21	07:00:00	Otobüs
30	2	34	1	1	2024-12-21	14:00:00	Otobüs
31	1	6	1	1	2024-12-21	09:00:00	Otobüs
32	1	1	6	1	2024-12-21	20:00:00	Otobüs
33	3	34	6	3	2024-12-22	17:00:00	Otobüs
34	3	6	34	2	2024-12-22	08:00:00	Otobüs
35	3	1	34	2	2024-12-22	16:00:00	Otobüs
36	2	34	1	3	2024-12-22	07:00:00	Otobüs
37	3	6	1	1	2024-12-22	09:00:00	Otobüs
38	3	1	6	2	2024-12-22	20:00:00	Otobüs
39	3	34	6	2	2024-12-23	16:00:00	Otobüs
40	2	6	34	3	2024-12-23	06:00:00	Otobüs
41	2	1	34	1	2024-12-23	17:00:00	Otobüs
42	2	34	1	1	2024-12-23	20:00:00	Otobüs
43	2	6	1	2	2024-12-23	08:00:00	Otobüs
44	1	1	6	1	2024-12-23	20:00:00	Otobüs
45	3	34	6	1	2024-12-24	19:00:00	Otobüs
46	3	6	34	1	2024-12-24	11:00:00	Otobüs
47	2	1	34	1	2024-12-24	07:00:00	Otobüs
48	3	34	1	3	2024-12-24	08:00:00	Otobüs
49	1	6	1	2	2024-12-24	09:00:00	Otobüs
50	2	1	6	3	2024-12-24	20:00:00	Otobüs
51	2	34	6	1	2024-12-25	14:00:00	Otobüs
52	2	6	34	1	2024-12-25	20:00:00	Otobüs
53	1	1	34	3	2024-12-25	10:00:00	Otobüs
54	1	34	1	1	2024-12-25	17:00:00	Otobüs
55	3	6	1	3	2024-12-25	19:00:00	Otobüs
56	1	1	6	2	2024-12-25	19:00:00	Otobüs
57	2	34	6	3	2024-12-26	10:00:00	Otobüs
58	1	6	34	3	2024-12-26	13:00:00	Otobüs
59	2	1	34	3	2024-12-26	13:00:00	Otobüs
60	3	34	1	1	2024-12-26	17:00:00	Otobüs
61	1	6	1	2	2024-12-26	16:00:00	Otobüs
62	3	1	6	2	2024-12-26	17:00:00	Otobüs
63	1	34	6	3	2024-12-27	14:00:00	Otobüs
64	1	6	34	1	2024-12-27	20:00:00	Otobüs
65	1	1	34	3	2024-12-27	10:00:00	Otobüs
66	2	34	1	2	2024-12-27	08:00:00	Otobüs
67	1	6	1	1	2024-12-27	12:00:00	Otobüs
68	2	1	6	1	2024-12-27	10:00:00	Otobüs
69	2	34	6	2	2024-12-28	15:00:00	Otobüs
70	2	6	34	2	2024-12-28	11:00:00	Otobüs
71	3	1	34	1	2024-12-28	10:00:00	Otobüs
72	3	34	1	3	2024-12-28	06:00:00	Otobüs
73	2	6	1	2	2024-12-28	20:00:00	Otobüs
74	1	1	6	3	2024-12-28	19:00:00	Otobüs
75	1	34	6	1	2024-12-29	12:00:00	Otobüs
76	3	6	34	3	2024-12-29	13:00:00	Otobüs
77	2	1	34	3	2024-12-29	06:00:00	Otobüs
78	1	34	1	1	2024-12-29	14:00:00	Otobüs
79	2	6	1	2	2024-12-29	10:00:00	Otobüs
80	1	1	6	1	2024-12-29	19:00:00	Otobüs
81	3	34	6	2	2024-12-30	14:00:00	Otobüs
82	1	6	34	2	2024-12-30	09:00:00	Otobüs
83	1	1	34	3	2024-12-30	16:00:00	Otobüs
84	2	34	1	2	2024-12-30	10:00:00	Otobüs
85	3	6	1	1	2024-12-30	15:00:00	Otobüs
86	2	1	6	2	2024-12-30	14:00:00	Otobüs
87	3	34	6	3	2024-12-31	18:00:00	Otobüs
88	2	6	34	2	2024-12-31	08:00:00	Otobüs
89	2	1	34	1	2024-12-31	20:00:00	Otobüs
90	3	34	1	1	2024-12-31	09:00:00	Otobüs
91	3	6	1	1	2024-12-31	12:00:00	Otobüs
92	3	1	6	2	2024-12-31	20:00:00	Otobüs
93	2	34	6	2	2025-01-01	13:00:00	Otobüs
94	1	6	34	1	2025-01-01	11:00:00	Otobüs
95	3	1	34	3	2025-01-01	16:00:00	Otobüs
96	1	34	1	1	2025-01-01	20:00:00	Otobüs
97	2	6	1	2	2025-01-01	11:00:00	Otobüs
98	1	1	6	2	2025-01-01	19:00:00	Otobüs
99	2	34	6	2	2025-01-02	15:00:00	Otobüs
100	1	6	34	2	2025-01-02	12:00:00	Otobüs
101	3	1	34	2	2025-01-02	14:00:00	Otobüs
102	1	34	1	2	2025-01-02	13:00:00	Otobüs
103	3	6	1	2	2025-01-02	08:00:00	Otobüs
104	1	1	6	2	2025-01-02	07:00:00	Otobüs
105	1	34	6	3	2025-01-03	10:00:00	Otobüs
106	3	6	34	1	2025-01-03	10:00:00	Otobüs
107	2	1	34	2	2025-01-03	11:00:00	Otobüs
108	3	34	1	2	2025-01-03	20:00:00	Otobüs
109	2	6	1	3	2025-01-03	18:00:00	Otobüs
110	2	1	6	1	2025-01-03	10:00:00	Otobüs
111	3	34	6	2	2025-01-04	18:00:00	Otobüs
112	2	6	34	2	2025-01-04	10:00:00	Otobüs
113	1	1	34	1	2025-01-04	17:00:00	Otobüs
114	2	34	1	1	2025-01-04	06:00:00	Otobüs
115	1	6	1	2	2025-01-04	06:00:00	Otobüs
116	2	1	6	1	2025-01-04	14:00:00	Otobüs
117	3	34	6	2	2025-01-05	15:00:00	Otobüs
118	1	6	34	2	2025-01-05	18:00:00	Otobüs
119	2	1	34	3	2025-01-05	06:00:00	Otobüs
120	2	34	1	1	2025-01-05	10:00:00	Otobüs
121	2	6	1	3	2025-01-05	09:00:00	Otobüs
122	2	1	6	3	2025-01-05	10:00:00	Otobüs
124	1	2	3	1	2024-01-01	10:00:00	Otobüs
125	1	1	2	3	2024-12-21	11:00:00	Otobüs
126	2	2	1	2	2024-12-21	08:00:00	Otobüs
127	2	54	34	2	2024-12-21	07:00:00	Otobüs
128	1	34	54	2	2024-12-21	14:00:00	Otobüs
129	3	6	35	3	2024-12-21	06:00:00	Otobüs
130	2	1	6	2	2024-12-21	17:00:00	Otobüs
131	1	12	45	3	2024-12-21	07:00:00	Otobüs
132	3	7	23	3	2024-12-21	10:00:00	Otobüs
133	2	81	3	3	2024-12-21	06:00:00	Otobüs
134	3	16	58	2	2024-12-21	17:00:00	Otobüs
135	3	29	72	1	2024-12-21	06:00:00	Otobüs
136	2	5	49	3	2024-12-21	20:00:00	Otobüs
137	2	37	64	3	2024-12-21	13:00:00	Otobüs
138	3	2	34	1	2024-12-21	09:00:00	Otobüs
139	3	21	40	3	2024-12-21	16:00:00	Otobüs
140	1	53	11	2	2024-12-21	17:00:00	Otobüs
141	1	9	78	2	2024-12-21	09:00:00	Otobüs
142	1	62	26	2	2024-12-21	20:00:00	Otobüs
143	1	17	35	3	2024-12-21	14:00:00	Otobüs
144	2	14	68	3	2024-12-21	08:00:00	Otobüs
145	2	74	47	1	2024-12-21	18:00:00	Otobüs
146	3	6	80	1	2024-12-21	07:00:00	Otobüs
147	2	50	28	2	2024-12-21	14:00:00	Otobüs
148	2	44	39	1	2024-12-21	10:00:00	Otobüs
149	3	8	59	2	2024-12-21	16:00:00	Otobüs
150	2	19	65	1	2024-12-21	11:00:00	Otobüs
151	1	31	77	3	2024-12-21	20:00:00	Otobüs
152	2	4	73	3	2024-12-21	15:00:00	Otobüs
153	1	20	42	1	2024-12-21	09:00:00	Otobüs
154	2	25	66	2	2024-12-21	13:00:00	Otobüs
155	2	48	56	2	2024-12-21	14:00:00	Otobüs
156	3	22	12	3	2024-12-21	11:00:00	Otobüs
157	1	63	30	1	2024-12-21	07:00:00	Otobüs
158	1	10	18	3	2024-12-21	09:00:00	Otobüs
159	1	55	38	2	2024-12-21	14:00:00	Otobüs
160	3	32	70	3	2024-12-21	19:00:00	Otobüs
161	2	1	2	3	2024-12-22	09:00:00	Otobüs
162	2	2	1	2	2024-12-22	13:00:00	Otobüs
163	2	54	34	2	2024-12-22	20:00:00	Otobüs
164	2	34	54	2	2024-12-22	15:00:00	Otobüs
165	1	6	35	3	2024-12-22	17:00:00	Otobüs
166	1	1	6	1	2024-12-22	09:00:00	Otobüs
167	3	12	45	2	2024-12-22	20:00:00	Otobüs
168	1	7	23	2	2024-12-22	19:00:00	Otobüs
169	3	81	3	3	2024-12-22	19:00:00	Otobüs
170	2	16	58	2	2024-12-22	16:00:00	Otobüs
171	1	29	72	2	2024-12-22	15:00:00	Otobüs
172	2	5	49	1	2024-12-22	07:00:00	Otobüs
173	3	37	64	3	2024-12-22	06:00:00	Otobüs
174	3	2	34	3	2024-12-22	10:00:00	Otobüs
175	3	21	40	2	2024-12-22	08:00:00	Otobüs
176	2	53	11	2	2024-12-22	15:00:00	Otobüs
177	3	9	78	1	2024-12-22	14:00:00	Otobüs
178	1	62	26	2	2024-12-22	07:00:00	Otobüs
179	3	17	35	2	2024-12-22	19:00:00	Otobüs
180	1	14	68	1	2024-12-22	07:00:00	Otobüs
181	3	74	47	1	2024-12-22	13:00:00	Otobüs
182	2	6	80	2	2024-12-22	16:00:00	Otobüs
183	1	50	28	1	2024-12-22	12:00:00	Otobüs
184	2	44	39	2	2024-12-22	10:00:00	Otobüs
185	3	8	59	2	2024-12-22	11:00:00	Otobüs
186	3	19	65	1	2024-12-22	10:00:00	Otobüs
187	1	31	77	1	2024-12-22	17:00:00	Otobüs
188	1	4	73	3	2024-12-22	13:00:00	Otobüs
189	3	20	42	2	2024-12-22	13:00:00	Otobüs
190	3	25	66	1	2024-12-22	08:00:00	Otobüs
191	1	48	56	2	2024-12-22	12:00:00	Otobüs
192	2	22	12	2	2024-12-22	19:00:00	Otobüs
193	2	63	30	2	2024-12-22	06:00:00	Otobüs
194	3	10	18	1	2024-12-22	18:00:00	Otobüs
195	1	55	38	1	2024-12-22	12:00:00	Otobüs
196	1	32	70	3	2024-12-22	06:00:00	Otobüs
197	1	1	2	1	2024-12-23	09:00:00	Otobüs
198	2	2	1	3	2024-12-23	09:00:00	Otobüs
199	1	54	34	1	2024-12-23	06:00:00	Otobüs
200	1	34	54	2	2024-12-23	07:00:00	Otobüs
201	1	6	35	2	2024-12-23	12:00:00	Otobüs
202	3	1	6	1	2024-12-23	16:00:00	Otobüs
203	2	12	45	3	2024-12-23	19:00:00	Otobüs
204	2	7	23	2	2024-12-23	10:00:00	Otobüs
205	1	81	3	1	2024-12-23	19:00:00	Otobüs
206	2	16	58	3	2024-12-23	06:00:00	Otobüs
207	1	29	72	1	2024-12-23	11:00:00	Otobüs
208	2	5	49	1	2024-12-23	12:00:00	Otobüs
209	1	37	64	3	2024-12-23	20:00:00	Otobüs
210	2	2	34	2	2024-12-23	16:00:00	Otobüs
211	2	21	40	1	2024-12-23	11:00:00	Otobüs
212	3	53	11	2	2024-12-23	10:00:00	Otobüs
213	1	9	78	2	2024-12-23	07:00:00	Otobüs
214	2	62	26	2	2024-12-23	06:00:00	Otobüs
215	1	17	35	2	2024-12-23	19:00:00	Otobüs
216	2	14	68	3	2024-12-23	18:00:00	Otobüs
217	1	74	47	2	2024-12-23	10:00:00	Otobüs
218	2	6	80	3	2024-12-23	07:00:00	Otobüs
219	1	50	28	3	2024-12-23	19:00:00	Otobüs
220	2	44	39	1	2024-12-23	16:00:00	Otobüs
221	1	8	59	2	2024-12-23	13:00:00	Otobüs
222	2	19	65	2	2024-12-23	15:00:00	Otobüs
223	1	31	77	3	2024-12-23	10:00:00	Otobüs
224	1	4	73	2	2024-12-23	12:00:00	Otobüs
225	1	20	42	2	2024-12-23	12:00:00	Otobüs
226	1	25	66	2	2024-12-23	10:00:00	Otobüs
227	2	48	56	1	2024-12-23	15:00:00	Otobüs
228	3	22	12	1	2024-12-23	10:00:00	Otobüs
229	1	63	30	2	2024-12-23	20:00:00	Otobüs
230	1	10	18	1	2024-12-23	10:00:00	Otobüs
231	3	55	38	1	2024-12-23	09:00:00	Otobüs
232	1	32	70	2	2024-12-23	11:00:00	Otobüs
233	2	1	2	3	2024-12-24	15:00:00	Otobüs
234	3	2	1	2	2024-12-24	14:00:00	Otobüs
235	2	54	34	1	2024-12-24	08:00:00	Otobüs
236	1	34	54	2	2024-12-24	15:00:00	Otobüs
237	2	6	35	2	2024-12-24	20:00:00	Otobüs
238	3	1	6	1	2024-12-24	18:00:00	Otobüs
239	2	12	45	2	2024-12-24	16:00:00	Otobüs
240	3	7	23	3	2024-12-24	10:00:00	Otobüs
241	2	81	3	2	2024-12-24	15:00:00	Otobüs
242	3	16	58	3	2024-12-24	17:00:00	Otobüs
243	3	29	72	2	2024-12-24	08:00:00	Otobüs
244	1	5	49	2	2024-12-24	19:00:00	Otobüs
245	3	37	64	1	2024-12-24	14:00:00	Otobüs
246	1	2	34	3	2024-12-24	20:00:00	Otobüs
247	3	21	40	1	2024-12-24	16:00:00	Otobüs
248	1	53	11	2	2024-12-24	14:00:00	Otobüs
249	2	9	78	1	2024-12-24	20:00:00	Otobüs
250	3	62	26	1	2024-12-24	12:00:00	Otobüs
251	1	17	35	3	2024-12-24	06:00:00	Otobüs
252	2	14	68	1	2024-12-24	10:00:00	Otobüs
253	3	74	47	1	2024-12-24	11:00:00	Otobüs
254	1	6	80	1	2024-12-24	11:00:00	Otobüs
255	3	50	28	1	2024-12-24	09:00:00	Otobüs
256	3	44	39	2	2024-12-24	07:00:00	Otobüs
257	1	8	59	2	2024-12-24	08:00:00	Otobüs
258	3	19	65	3	2024-12-24	13:00:00	Otobüs
259	1	31	77	2	2024-12-24	07:00:00	Otobüs
260	2	4	73	3	2024-12-24	19:00:00	Otobüs
261	2	20	42	2	2024-12-24	09:00:00	Otobüs
262	1	25	66	1	2024-12-24	19:00:00	Otobüs
263	3	48	56	3	2024-12-24	20:00:00	Otobüs
264	1	22	12	3	2024-12-24	07:00:00	Otobüs
265	3	63	30	2	2024-12-24	20:00:00	Otobüs
266	2	10	18	3	2024-12-24	20:00:00	Otobüs
267	1	55	38	2	2024-12-24	07:00:00	Otobüs
268	1	32	70	2	2024-12-24	16:00:00	Otobüs
269	2	1	2	1	2024-12-25	08:00:00	Otobüs
270	1	2	1	2	2024-12-25	10:00:00	Otobüs
271	2	54	34	2	2024-12-25	08:00:00	Otobüs
272	2	34	54	2	2024-12-25	07:00:00	Otobüs
273	3	6	35	2	2024-12-25	19:00:00	Otobüs
274	2	1	6	2	2024-12-25	10:00:00	Otobüs
275	2	12	45	1	2024-12-25	15:00:00	Otobüs
276	2	7	23	3	2024-12-25	12:00:00	Otobüs
277	1	81	3	3	2024-12-25	08:00:00	Otobüs
278	2	16	58	3	2024-12-25	14:00:00	Otobüs
279	3	29	72	2	2024-12-25	13:00:00	Otobüs
280	3	5	49	2	2024-12-25	16:00:00	Otobüs
281	3	37	64	2	2024-12-25	10:00:00	Otobüs
282	2	2	34	3	2024-12-25	17:00:00	Otobüs
283	3	21	40	3	2024-12-25	14:00:00	Otobüs
284	1	53	11	3	2024-12-25	19:00:00	Otobüs
285	1	9	78	1	2024-12-25	16:00:00	Otobüs
286	2	62	26	2	2024-12-25	06:00:00	Otobüs
287	2	17	35	2	2024-12-25	08:00:00	Otobüs
288	2	14	68	3	2024-12-25	20:00:00	Otobüs
289	1	74	47	3	2024-12-25	19:00:00	Otobüs
290	2	6	80	3	2024-12-25	18:00:00	Otobüs
291	2	50	28	1	2024-12-25	15:00:00	Otobüs
292	2	44	39	3	2024-12-25	13:00:00	Otobüs
293	2	8	59	3	2024-12-25	09:00:00	Otobüs
294	3	19	65	2	2024-12-25	13:00:00	Otobüs
295	3	31	77	3	2024-12-25	19:00:00	Otobüs
296	1	4	73	3	2024-12-25	20:00:00	Otobüs
297	1	20	42	2	2024-12-25	19:00:00	Otobüs
298	1	25	66	3	2024-12-25	06:00:00	Otobüs
299	1	48	56	1	2024-12-25	15:00:00	Otobüs
300	2	22	12	1	2024-12-25	14:00:00	Otobüs
301	2	63	30	3	2024-12-25	17:00:00	Otobüs
302	3	10	18	1	2024-12-25	20:00:00	Otobüs
303	3	55	38	2	2024-12-25	10:00:00	Otobüs
304	3	32	70	1	2024-12-25	13:00:00	Otobüs
305	2	1	2	3	2024-12-26	16:00:00	Otobüs
306	2	2	1	1	2024-12-26	09:00:00	Otobüs
307	1	54	34	3	2024-12-26	07:00:00	Otobüs
308	3	34	54	1	2024-12-26	14:00:00	Otobüs
309	1	6	35	2	2024-12-26	09:00:00	Otobüs
310	1	1	6	2	2024-12-26	13:00:00	Otobüs
311	2	12	45	3	2024-12-26	10:00:00	Otobüs
312	3	7	23	1	2024-12-26	14:00:00	Otobüs
313	3	81	3	1	2024-12-26	13:00:00	Otobüs
314	3	16	58	3	2024-12-26	13:00:00	Otobüs
315	3	29	72	3	2024-12-26	11:00:00	Otobüs
316	1	5	49	2	2024-12-26	17:00:00	Otobüs
317	3	37	64	3	2024-12-26	14:00:00	Otobüs
318	2	2	34	1	2024-12-26	12:00:00	Otobüs
319	1	21	40	2	2024-12-26	15:00:00	Otobüs
320	1	53	11	3	2024-12-26	06:00:00	Otobüs
321	2	9	78	1	2024-12-26	20:00:00	Otobüs
322	1	62	26	3	2024-12-26	20:00:00	Otobüs
323	1	17	35	1	2024-12-26	06:00:00	Otobüs
324	3	14	68	2	2024-12-26	18:00:00	Otobüs
325	3	74	47	1	2024-12-26	06:00:00	Otobüs
326	1	6	80	1	2024-12-26	09:00:00	Otobüs
327	1	50	28	1	2024-12-26	10:00:00	Otobüs
328	2	44	39	2	2024-12-26	09:00:00	Otobüs
329	1	8	59	2	2024-12-26	17:00:00	Otobüs
330	2	19	65	3	2024-12-26	06:00:00	Otobüs
331	3	31	77	1	2024-12-26	14:00:00	Otobüs
332	2	4	73	2	2024-12-26	20:00:00	Otobüs
333	3	20	42	1	2024-12-26	17:00:00	Otobüs
334	1	25	66	3	2024-12-26	10:00:00	Otobüs
335	2	48	56	3	2024-12-26	06:00:00	Otobüs
336	1	22	12	3	2024-12-26	07:00:00	Otobüs
337	3	63	30	2	2024-12-26	20:00:00	Otobüs
338	3	10	18	2	2024-12-26	09:00:00	Otobüs
339	1	55	38	1	2024-12-26	12:00:00	Otobüs
340	1	32	70	3	2024-12-26	10:00:00	Otobüs
341	3	1	2	3	2024-12-27	07:00:00	Otobüs
342	3	2	1	1	2024-12-27	13:00:00	Otobüs
343	3	54	34	2	2024-12-27	09:00:00	Otobüs
344	3	34	54	1	2024-12-27	09:00:00	Otobüs
345	2	6	35	3	2024-12-27	16:00:00	Otobüs
346	3	1	6	1	2024-12-27	10:00:00	Otobüs
347	1	12	45	1	2024-12-27	15:00:00	Otobüs
348	2	7	23	1	2024-12-27	12:00:00	Otobüs
349	2	81	3	3	2024-12-27	09:00:00	Otobüs
350	2	16	58	2	2024-12-27	14:00:00	Otobüs
351	1	29	72	2	2024-12-27	07:00:00	Otobüs
352	2	5	49	3	2024-12-27	13:00:00	Otobüs
353	2	37	64	1	2024-12-27	10:00:00	Otobüs
354	1	2	34	1	2024-12-27	09:00:00	Otobüs
355	1	21	40	1	2024-12-27	08:00:00	Otobüs
356	3	53	11	1	2024-12-27	17:00:00	Otobüs
357	2	9	78	1	2024-12-27	13:00:00	Otobüs
358	2	62	26	1	2024-12-27	17:00:00	Otobüs
359	3	17	35	2	2024-12-27	08:00:00	Otobüs
360	3	14	68	3	2024-12-27	20:00:00	Otobüs
361	3	74	47	2	2024-12-27	19:00:00	Otobüs
362	3	6	80	3	2024-12-27	15:00:00	Otobüs
363	3	50	28	3	2024-12-27	20:00:00	Otobüs
364	2	44	39	1	2024-12-27	16:00:00	Otobüs
365	2	8	59	2	2024-12-27	09:00:00	Otobüs
366	3	19	65	3	2024-12-27	09:00:00	Otobüs
367	2	31	77	2	2024-12-27	20:00:00	Otobüs
368	3	4	73	3	2024-12-27	06:00:00	Otobüs
369	2	20	42	2	2024-12-27	11:00:00	Otobüs
370	3	25	66	1	2024-12-27	18:00:00	Otobüs
371	2	48	56	1	2024-12-27	17:00:00	Otobüs
372	3	22	12	1	2024-12-27	15:00:00	Otobüs
373	2	63	30	2	2024-12-27	07:00:00	Otobüs
374	1	10	18	2	2024-12-27	18:00:00	Otobüs
375	3	55	38	1	2024-12-27	16:00:00	Otobüs
376	1	32	70	1	2024-12-27	16:00:00	Otobüs
377	3	1	2	2	2024-12-28	11:00:00	Otobüs
378	1	2	1	2	2024-12-28	11:00:00	Otobüs
379	3	54	34	2	2024-12-28	06:00:00	Otobüs
380	1	34	54	2	2024-12-28	09:00:00	Otobüs
381	3	6	35	1	2024-12-28	18:00:00	Otobüs
382	3	1	6	2	2024-12-28	19:00:00	Otobüs
383	2	12	45	2	2024-12-28	12:00:00	Otobüs
384	1	7	23	2	2024-12-28	06:00:00	Otobüs
385	3	81	3	2	2024-12-28	15:00:00	Otobüs
386	2	16	58	3	2024-12-28	11:00:00	Otobüs
387	3	29	72	2	2024-12-28	13:00:00	Otobüs
388	3	5	49	3	2024-12-28	12:00:00	Otobüs
389	3	37	64	3	2024-12-28	09:00:00	Otobüs
390	1	2	34	3	2024-12-28	10:00:00	Otobüs
391	3	21	40	2	2024-12-28	07:00:00	Otobüs
392	2	53	11	1	2024-12-28	06:00:00	Otobüs
393	2	9	78	1	2024-12-28	20:00:00	Otobüs
394	2	62	26	1	2024-12-28	15:00:00	Otobüs
395	2	17	35	1	2024-12-28	13:00:00	Otobüs
396	3	14	68	1	2024-12-28	13:00:00	Otobüs
397	1	74	47	1	2024-12-28	12:00:00	Otobüs
398	3	6	80	1	2024-12-28	12:00:00	Otobüs
399	1	50	28	1	2024-12-28	13:00:00	Otobüs
400	2	44	39	2	2024-12-28	06:00:00	Otobüs
401	2	8	59	2	2024-12-28	20:00:00	Otobüs
402	1	19	65	3	2024-12-28	17:00:00	Otobüs
403	1	31	77	2	2024-12-28	19:00:00	Otobüs
404	2	4	73	3	2024-12-28	13:00:00	Otobüs
405	3	20	42	1	2024-12-28	19:00:00	Otobüs
406	2	25	66	2	2024-12-28	15:00:00	Otobüs
407	3	48	56	1	2024-12-28	07:00:00	Otobüs
408	2	22	12	3	2024-12-28	14:00:00	Otobüs
409	3	63	30	3	2024-12-28	19:00:00	Otobüs
410	2	10	18	2	2024-12-28	09:00:00	Otobüs
411	1	55	38	3	2024-12-28	18:00:00	Otobüs
412	2	32	70	2	2024-12-28	13:00:00	Otobüs
413	1	1	2	1	2024-12-29	15:00:00	Otobüs
414	2	2	1	2	2024-12-29	12:00:00	Otobüs
415	1	54	34	3	2024-12-29	15:00:00	Otobüs
416	1	34	54	2	2024-12-29	15:00:00	Otobüs
417	2	6	35	2	2024-12-29	17:00:00	Otobüs
418	1	1	6	1	2024-12-29	20:00:00	Otobüs
419	1	12	45	1	2024-12-29	16:00:00	Otobüs
420	2	7	23	3	2024-12-29	12:00:00	Otobüs
421	2	81	3	1	2024-12-29	18:00:00	Otobüs
422	2	16	58	1	2024-12-29	11:00:00	Otobüs
423	2	29	72	2	2024-12-29	18:00:00	Otobüs
424	3	5	49	3	2024-12-29	09:00:00	Otobüs
425	3	37	64	2	2024-12-29	19:00:00	Otobüs
426	3	2	34	1	2024-12-29	08:00:00	Otobüs
427	1	21	40	2	2024-12-29	12:00:00	Otobüs
428	3	53	11	2	2024-12-29	19:00:00	Otobüs
429	1	9	78	2	2024-12-29	19:00:00	Otobüs
430	3	62	26	1	2024-12-29	15:00:00	Otobüs
431	2	17	35	3	2024-12-29	10:00:00	Otobüs
432	1	14	68	3	2024-12-29	07:00:00	Otobüs
433	3	74	47	3	2024-12-29	14:00:00	Otobüs
434	1	6	80	2	2024-12-29	20:00:00	Otobüs
435	2	50	28	1	2024-12-29	20:00:00	Otobüs
436	3	44	39	2	2024-12-29	14:00:00	Otobüs
437	1	8	59	2	2024-12-29	16:00:00	Otobüs
438	1	19	65	2	2024-12-29	08:00:00	Otobüs
439	3	31	77	1	2024-12-29	10:00:00	Otobüs
440	2	4	73	2	2024-12-29	06:00:00	Otobüs
441	3	20	42	1	2024-12-29	13:00:00	Otobüs
442	2	25	66	1	2024-12-29	10:00:00	Otobüs
443	2	48	56	1	2024-12-29	15:00:00	Otobüs
444	3	22	12	3	2024-12-29	08:00:00	Otobüs
445	3	63	30	1	2024-12-29	09:00:00	Otobüs
446	1	10	18	2	2024-12-29	11:00:00	Otobüs
447	1	55	38	3	2024-12-29	10:00:00	Otobüs
448	2	32	70	1	2024-12-29	08:00:00	Otobüs
449	3	1	2	1	2024-12-30	07:00:00	Otobüs
450	1	2	1	1	2024-12-30	09:00:00	Otobüs
451	1	54	34	2	2024-12-30	10:00:00	Otobüs
452	1	34	54	3	2024-12-30	07:00:00	Otobüs
453	3	6	35	3	2024-12-30	18:00:00	Otobüs
454	3	1	6	3	2024-12-30	18:00:00	Otobüs
455	2	12	45	3	2024-12-30	11:00:00	Otobüs
456	3	7	23	1	2024-12-30	06:00:00	Otobüs
457	3	81	3	3	2024-12-30	06:00:00	Otobüs
458	3	16	58	2	2024-12-30	11:00:00	Otobüs
459	3	29	72	3	2024-12-30	09:00:00	Otobüs
460	2	5	49	3	2024-12-30	08:00:00	Otobüs
461	2	37	64	3	2024-12-30	20:00:00	Otobüs
462	1	2	34	1	2024-12-30	08:00:00	Otobüs
463	2	21	40	1	2024-12-30	06:00:00	Otobüs
464	2	53	11	1	2024-12-30	08:00:00	Otobüs
465	3	9	78	1	2024-12-30	08:00:00	Otobüs
466	1	62	26	2	2024-12-30	06:00:00	Otobüs
467	3	17	35	1	2024-12-30	10:00:00	Otobüs
468	2	14	68	2	2024-12-30	18:00:00	Otobüs
469	1	74	47	1	2024-12-30	17:00:00	Otobüs
470	1	6	80	1	2024-12-30	20:00:00	Otobüs
471	1	50	28	2	2024-12-30	20:00:00	Otobüs
472	1	44	39	2	2024-12-30	19:00:00	Otobüs
473	2	8	59	1	2024-12-30	08:00:00	Otobüs
474	3	19	65	1	2024-12-30	14:00:00	Otobüs
475	2	31	77	2	2024-12-30	08:00:00	Otobüs
476	3	4	73	3	2024-12-30	11:00:00	Otobüs
477	2	20	42	2	2024-12-30	15:00:00	Otobüs
478	3	25	66	2	2024-12-30	18:00:00	Otobüs
479	3	48	56	1	2024-12-30	07:00:00	Otobüs
480	2	22	12	2	2024-12-30	16:00:00	Otobüs
481	1	63	30	3	2024-12-30	18:00:00	Otobüs
482	3	10	18	1	2024-12-30	16:00:00	Otobüs
483	3	55	38	3	2024-12-30	17:00:00	Otobüs
484	3	32	70	2	2024-12-30	19:00:00	Otobüs
485	3	1	2	1	2024-12-31	14:00:00	Otobüs
486	1	2	1	2	2024-12-31	15:00:00	Otobüs
487	3	54	34	3	2024-12-31	08:00:00	Otobüs
488	1	34	54	2	2024-12-31	16:00:00	Otobüs
489	2	6	35	1	2024-12-31	20:00:00	Otobüs
490	2	1	6	2	2024-12-31	14:00:00	Otobüs
491	3	12	45	2	2024-12-31	10:00:00	Otobüs
492	2	7	23	1	2024-12-31	09:00:00	Otobüs
493	1	81	3	3	2024-12-31	13:00:00	Otobüs
494	3	16	58	1	2024-12-31	18:00:00	Otobüs
495	3	29	72	2	2024-12-31	14:00:00	Otobüs
496	1	5	49	3	2024-12-31	12:00:00	Otobüs
497	1	37	64	1	2024-12-31	07:00:00	Otobüs
498	1	2	34	2	2024-12-31	08:00:00	Otobüs
499	3	21	40	2	2024-12-31	16:00:00	Otobüs
500	1	53	11	3	2024-12-31	20:00:00	Otobüs
501	1	9	78	2	2024-12-31	16:00:00	Otobüs
502	3	62	26	3	2024-12-31	08:00:00	Otobüs
503	3	17	35	3	2024-12-31	07:00:00	Otobüs
504	1	14	68	1	2024-12-31	18:00:00	Otobüs
505	1	74	47	3	2024-12-31	11:00:00	Otobüs
506	1	6	80	3	2024-12-31	11:00:00	Otobüs
507	3	50	28	2	2024-12-31	17:00:00	Otobüs
508	1	44	39	1	2024-12-31	07:00:00	Otobüs
509	3	8	59	1	2024-12-31	17:00:00	Otobüs
510	3	19	65	3	2024-12-31	08:00:00	Otobüs
511	1	31	77	1	2024-12-31	13:00:00	Otobüs
512	3	4	73	3	2024-12-31	08:00:00	Otobüs
513	2	20	42	3	2024-12-31	20:00:00	Otobüs
514	1	25	66	3	2024-12-31	17:00:00	Otobüs
515	2	48	56	2	2024-12-31	09:00:00	Otobüs
516	3	22	12	1	2024-12-31	14:00:00	Otobüs
517	2	63	30	1	2024-12-31	19:00:00	Otobüs
518	1	10	18	2	2024-12-31	19:00:00	Otobüs
519	1	55	38	1	2024-12-31	11:00:00	Otobüs
520	1	32	70	1	2024-12-31	08:00:00	Otobüs
521	2	1	2	3	2025-01-01	13:00:00	Otobüs
522	3	2	1	1	2025-01-01	12:00:00	Otobüs
523	1	54	34	2	2025-01-01	16:00:00	Otobüs
524	1	34	54	1	2025-01-01	08:00:00	Otobüs
525	1	6	35	2	2025-01-01	15:00:00	Otobüs
526	1	1	6	2	2025-01-01	09:00:00	Otobüs
527	3	12	45	3	2025-01-01	06:00:00	Otobüs
528	1	7	23	1	2025-01-01	08:00:00	Otobüs
529	1	81	3	1	2025-01-01	12:00:00	Otobüs
530	1	16	58	3	2025-01-01	16:00:00	Otobüs
531	3	29	72	3	2025-01-01	13:00:00	Otobüs
532	3	5	49	3	2025-01-01	14:00:00	Otobüs
533	1	37	64	2	2025-01-01	10:00:00	Otobüs
534	2	2	34	2	2025-01-01	18:00:00	Otobüs
535	1	21	40	1	2025-01-01	08:00:00	Otobüs
536	1	53	11	1	2025-01-01	16:00:00	Otobüs
537	1	9	78	1	2025-01-01	10:00:00	Otobüs
538	1	62	26	2	2025-01-01	20:00:00	Otobüs
539	1	17	35	1	2025-01-01	08:00:00	Otobüs
540	1	14	68	1	2025-01-01	15:00:00	Otobüs
541	3	74	47	1	2025-01-01	11:00:00	Otobüs
542	2	6	80	1	2025-01-01	11:00:00	Otobüs
543	3	50	28	1	2025-01-01	15:00:00	Otobüs
544	2	44	39	2	2025-01-01	19:00:00	Otobüs
545	2	8	59	1	2025-01-01	13:00:00	Otobüs
546	1	19	65	3	2025-01-01	15:00:00	Otobüs
547	3	31	77	1	2025-01-01	19:00:00	Otobüs
548	3	4	73	3	2025-01-01	15:00:00	Otobüs
549	1	20	42	2	2025-01-01	15:00:00	Otobüs
550	3	25	66	3	2025-01-01	07:00:00	Otobüs
551	2	48	56	1	2025-01-01	07:00:00	Otobüs
552	3	22	12	3	2025-01-01	17:00:00	Otobüs
553	2	63	30	3	2025-01-01	12:00:00	Otobüs
554	1	10	18	3	2025-01-01	06:00:00	Otobüs
555	2	55	38	3	2025-01-01	07:00:00	Otobüs
556	1	32	70	3	2025-01-01	16:00:00	Otobüs
557	3	1	2	3	2025-01-02	19:00:00	Otobüs
558	3	2	1	2	2025-01-02	15:00:00	Otobüs
559	1	54	34	2	2025-01-02	06:00:00	Otobüs
560	2	34	54	3	2025-01-02	10:00:00	Otobüs
561	1	6	35	2	2025-01-02	07:00:00	Otobüs
562	1	1	6	1	2025-01-02	17:00:00	Otobüs
563	3	12	45	3	2025-01-02	20:00:00	Otobüs
564	3	7	23	1	2025-01-02	12:00:00	Otobüs
565	2	81	3	2	2025-01-02	13:00:00	Otobüs
566	1	16	58	3	2025-01-02	07:00:00	Otobüs
567	2	29	72	3	2025-01-02	09:00:00	Otobüs
568	2	5	49	2	2025-01-02	11:00:00	Otobüs
569	2	37	64	1	2025-01-02	06:00:00	Otobüs
570	3	2	34	2	2025-01-02	17:00:00	Otobüs
571	1	21	40	3	2025-01-02	14:00:00	Otobüs
572	2	53	11	2	2025-01-02	07:00:00	Otobüs
573	3	9	78	3	2025-01-02	17:00:00	Otobüs
574	1	62	26	3	2025-01-02	16:00:00	Otobüs
575	2	17	35	2	2025-01-02	06:00:00	Otobüs
576	2	14	68	2	2025-01-02	16:00:00	Otobüs
577	2	74	47	3	2025-01-02	19:00:00	Otobüs
578	3	6	80	3	2025-01-02	16:00:00	Otobüs
579	3	50	28	1	2025-01-02	16:00:00	Otobüs
580	1	44	39	1	2025-01-02	12:00:00	Otobüs
581	1	8	59	2	2025-01-02	19:00:00	Otobüs
582	2	19	65	2	2025-01-02	12:00:00	Otobüs
583	2	31	77	2	2025-01-02	09:00:00	Otobüs
584	2	4	73	2	2025-01-02	16:00:00	Otobüs
585	2	20	42	2	2025-01-02	19:00:00	Otobüs
586	1	25	66	1	2025-01-02	13:00:00	Otobüs
587	2	48	56	1	2025-01-02	08:00:00	Otobüs
588	2	22	12	2	2025-01-02	10:00:00	Otobüs
589	1	63	30	3	2025-01-02	07:00:00	Otobüs
590	1	10	18	2	2025-01-02	11:00:00	Otobüs
591	3	55	38	2	2025-01-02	08:00:00	Otobüs
592	1	32	70	3	2025-01-02	09:00:00	Otobüs
593	1	1	2	2	2025-01-03	18:00:00	Otobüs
594	1	2	1	1	2025-01-03	19:00:00	Otobüs
595	2	54	34	3	2025-01-03	14:00:00	Otobüs
596	2	34	54	3	2025-01-03	11:00:00	Otobüs
597	2	6	35	3	2025-01-03	18:00:00	Otobüs
598	2	1	6	2	2025-01-03	17:00:00	Otobüs
599	3	12	45	1	2025-01-03	12:00:00	Otobüs
600	2	7	23	2	2025-01-03	12:00:00	Otobüs
601	1	81	3	1	2025-01-03	13:00:00	Otobüs
602	1	16	58	2	2025-01-03	14:00:00	Otobüs
603	1	29	72	3	2025-01-03	12:00:00	Otobüs
604	2	5	49	1	2025-01-03	19:00:00	Otobüs
605	2	37	64	2	2025-01-03	16:00:00	Otobüs
606	2	2	34	1	2025-01-03	06:00:00	Otobüs
607	1	21	40	2	2025-01-03	13:00:00	Otobüs
608	2	53	11	1	2025-01-03	13:00:00	Otobüs
609	3	9	78	3	2025-01-03	14:00:00	Otobüs
610	1	62	26	2	2025-01-03	10:00:00	Otobüs
611	3	17	35	3	2025-01-03	11:00:00	Otobüs
612	1	14	68	3	2025-01-03	10:00:00	Otobüs
613	3	74	47	1	2025-01-03	07:00:00	Otobüs
614	3	6	80	1	2025-01-03	09:00:00	Otobüs
615	1	50	28	3	2025-01-03	17:00:00	Otobüs
616	2	44	39	1	2025-01-03	11:00:00	Otobüs
617	1	8	59	3	2025-01-03	20:00:00	Otobüs
618	1	19	65	3	2025-01-03	12:00:00	Otobüs
619	1	31	77	3	2025-01-03	06:00:00	Otobüs
620	2	4	73	2	2025-01-03	18:00:00	Otobüs
621	1	20	42	1	2025-01-03	10:00:00	Otobüs
622	2	25	66	1	2025-01-03	16:00:00	Otobüs
623	2	48	56	2	2025-01-03	10:00:00	Otobüs
624	2	22	12	1	2025-01-03	14:00:00	Otobüs
625	3	63	30	1	2025-01-03	20:00:00	Otobüs
626	1	10	18	3	2025-01-03	16:00:00	Otobüs
627	3	55	38	2	2025-01-03	14:00:00	Otobüs
628	1	32	70	2	2025-01-03	07:00:00	Otobüs
629	3	1	2	1	2025-01-04	19:00:00	Otobüs
630	3	2	1	3	2025-01-04	13:00:00	Otobüs
631	3	54	34	2	2025-01-04	10:00:00	Otobüs
632	3	34	54	3	2025-01-04	15:00:00	Otobüs
633	2	6	35	1	2025-01-04	16:00:00	Otobüs
634	3	1	6	2	2025-01-04	14:00:00	Otobüs
635	3	12	45	2	2025-01-04	16:00:00	Otobüs
636	1	7	23	3	2025-01-04	13:00:00	Otobüs
637	2	81	3	1	2025-01-04	07:00:00	Otobüs
638	3	16	58	1	2025-01-04	17:00:00	Otobüs
639	1	29	72	2	2025-01-04	14:00:00	Otobüs
640	3	5	49	3	2025-01-04	10:00:00	Otobüs
641	3	37	64	1	2025-01-04	07:00:00	Otobüs
642	1	2	34	2	2025-01-04	06:00:00	Otobüs
643	3	21	40	3	2025-01-04	16:00:00	Otobüs
644	3	53	11	2	2025-01-04	11:00:00	Otobüs
645	1	9	78	1	2025-01-04	18:00:00	Otobüs
646	1	62	26	3	2025-01-04	12:00:00	Otobüs
647	1	17	35	2	2025-01-04	15:00:00	Otobüs
648	1	14	68	3	2025-01-04	18:00:00	Otobüs
649	2	74	47	1	2025-01-04	07:00:00	Otobüs
650	1	6	80	3	2025-01-04	07:00:00	Otobüs
651	1	50	28	2	2025-01-04	14:00:00	Otobüs
652	3	44	39	2	2025-01-04	17:00:00	Otobüs
653	3	8	59	2	2025-01-04	11:00:00	Otobüs
654	1	19	65	1	2025-01-04	11:00:00	Otobüs
655	2	31	77	1	2025-01-04	16:00:00	Otobüs
656	1	4	73	1	2025-01-04	14:00:00	Otobüs
657	3	20	42	1	2025-01-04	13:00:00	Otobüs
658	3	25	66	1	2025-01-04	13:00:00	Otobüs
659	3	48	56	1	2025-01-04	20:00:00	Otobüs
660	3	22	12	2	2025-01-04	07:00:00	Otobüs
661	2	63	30	2	2025-01-04	09:00:00	Otobüs
662	1	10	18	1	2025-01-04	20:00:00	Otobüs
663	1	55	38	3	2025-01-04	19:00:00	Otobüs
664	2	32	70	1	2025-01-04	07:00:00	Otobüs
665	2	1	2	1	2025-01-05	06:00:00	Otobüs
666	3	2	1	3	2025-01-05	17:00:00	Otobüs
667	3	54	34	3	2025-01-05	15:00:00	Otobüs
668	3	34	54	1	2025-01-05	19:00:00	Otobüs
669	3	6	35	1	2025-01-05	10:00:00	Otobüs
670	2	1	6	2	2025-01-05	06:00:00	Otobüs
671	1	12	45	3	2025-01-05	13:00:00	Otobüs
672	1	7	23	2	2025-01-05	17:00:00	Otobüs
673	2	81	3	1	2025-01-05	12:00:00	Otobüs
674	1	16	58	1	2025-01-05	19:00:00	Otobüs
675	3	29	72	3	2025-01-05	07:00:00	Otobüs
676	3	5	49	1	2025-01-05	16:00:00	Otobüs
677	3	37	64	3	2025-01-05	08:00:00	Otobüs
678	2	2	34	1	2025-01-05	17:00:00	Otobüs
679	3	21	40	2	2025-01-05	19:00:00	Otobüs
680	3	53	11	3	2025-01-05	07:00:00	Otobüs
681	3	9	78	1	2025-01-05	19:00:00	Otobüs
682	2	62	26	3	2025-01-05	18:00:00	Otobüs
683	1	17	35	3	2025-01-05	17:00:00	Otobüs
684	3	14	68	3	2025-01-05	10:00:00	Otobüs
685	3	74	47	3	2025-01-05	13:00:00	Otobüs
686	1	6	80	1	2025-01-05	09:00:00	Otobüs
687	1	50	28	3	2025-01-05	09:00:00	Otobüs
688	1	44	39	3	2025-01-05	09:00:00	Otobüs
689	2	8	59	1	2025-01-05	09:00:00	Otobüs
690	3	19	65	2	2025-01-05	09:00:00	Otobüs
691	1	31	77	1	2025-01-05	09:00:00	Otobüs
692	1	4	73	2	2025-01-05	10:00:00	Otobüs
693	3	20	42	2	2025-01-05	14:00:00	Otobüs
694	2	25	66	2	2025-01-05	09:00:00	Otobüs
695	2	48	56	2	2025-01-05	13:00:00	Otobüs
696	3	22	12	2	2025-01-05	19:00:00	Otobüs
697	1	63	30	2	2025-01-05	20:00:00	Otobüs
698	3	10	18	3	2025-01-05	09:00:00	Otobüs
699	1	55	38	2	2025-01-05	18:00:00	Otobüs
700	2	32	70	2	2025-01-05	08:00:00	Otobüs
3	1	32	35	1	2024-12-25	14:00:00	Otobüs
701	2	54	53	1	2024-12-23	\N	otobus
1000	2	54	53	1	2024-12-23	\N	otobus
\.


--
-- TOC entry 5113 (class 0 OID 16501)
-- Dependencies: 224
-- Data for Name: sehirler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sehirler (sehir_id, ad) FROM stdin;
1	Adana
2	Adıyaman
3	Afyonkarahisar
4	Ağrı
5	Amasya
6	Ankara
7	Antalya
8	Artvin
9	Aydın
10	Balıkesir
11	Bilecik
12	Bingöl
13	Bitlis
14	Bolu
15	Burdur
16	Bursa
17	Çanakkale
18	Çankırı
19	Çorum
20	Denizli
21	Diyarbakır
22	Edirne
23	Elazığ
24	Erzincan
25	Erzurum
26	Eskişehir
27	Gaziantep
28	Giresun
29	Gümüşhane
30	Hakkari
31	Hatay
32	Isparta
33	Mersin
34	İstanbul
35	İzmir
36	Kars
37	Kastamonu
38	Kayseri
39	Kırklareli
40	Kırşehir
41	Kocaeli
42	Konya
43	Kütahya
44	Malatya
45	Manisa
46	Kahramanmaraş
47	Mardin
48	Muğla
49	Muş
50	Nevşehir
51	Niğde
52	Ordu
53	Rize
54	Sakarya
55	Samsun
56	Siirt
57	Sinop
58	Sivas
59	Tekirdağ
60	Tokat
61	Trabzon
62	Tunceli
63	Şanlıurfa
64	Uşak
65	Van
66	Yozgat
67	Zonguldak
68	Aksaray
69	Bayburt
70	Karaman
71	Kırıkkale
72	Batman
73	Şırnak
74	Bartın
75	Ardahan
76	Iğdır
77	Yalova
78	Karabük
79	Kilis
80	Osmaniye
81	Düzce
\.


--
-- TOC entry 5129 (class 0 OID 16627)
-- Dependencies: 240
-- Data for Name: sikayetler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.sikayetler (sikayet_id, kullanici_id, sikayet_metni, sikayet_tarihi) FROM stdin;
1	1	Uçakta yemek servisi çok geç yapıldı.	2024-12-16 14:00:00
2	2	Otobüs çok eskiydi, koltuklar rahatsızdı.	2024-12-17 15:30:00
3	3	Tren gecikmeli geldi.	2024-12-18 16:45:00
4	4	Bagaj teslimi sırasında sorun yaşadım.	2024-12-19 17:00:00
10	8	Bagaj kayboldu.	2024-12-23 16:47:48.650469
5	8	şikayet	2024-12-23 17:05:56.411202
6	8	bagaj	2024-12-23 20:29:00.008626
\.


--
-- TOC entry 5139 (class 0 OID 16719)
-- Dependencies: 250
-- Data for Name: trenler; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.trenler (arac_id, tur, kapasite, firma_id, tren_id, vagon_sayisi, yemekli_vagon) FROM stdin;
7	Tren	300	3	1	10	t
8	Tren	250	3	2	8	f
3	\N	\N	\N	3	8	t
3	\N	\N	\N	4	10	f
\.


--
-- TOC entry 5137 (class 0 OID 16711)
-- Dependencies: 248
-- Data for Name: ucaklar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ucaklar (arac_id, tur, kapasite, firma_id, ucak_id, havayolu, business_koltuk_sayisi, ekonomi_koltuk_sayisi) FROM stdin;
5	Uçak	180	1	1	ABC Havayolları	20	160
6	Uçak	200	1	2	ABC Havayolları	25	175
1	\N	\N	\N	3	Türk Hava Yolları	20	180
1	\N	\N	\N	4	Anadolu Jet	15	150
\.


--
-- TOC entry 5171 (class 0 OID 0)
-- Dependencies: 221
-- Name: araclar_arac_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.araclar_arac_id_seq', 13, true);


--
-- TOC entry 5172 (class 0 OID 0)
-- Dependencies: 237
-- Name: bagajlar_bagaj_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bagajlar_bagaj_id_seq', 1, false);


--
-- TOC entry 5173 (class 0 OID 0)
-- Dependencies: 227
-- Name: biletler_bilet_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.biletler_bilet_id_seq', 59, true);


--
-- TOC entry 5174 (class 0 OID 0)
-- Dependencies: 219
-- Name: firmalar_firma_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.firmalar_firma_id_seq', 7, true);


--
-- TOC entry 5175 (class 0 OID 0)
-- Dependencies: 243
-- Name: hizmetler_hizmet_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.hizmetler_hizmet_id_seq', 4, true);


--
-- TOC entry 5176 (class 0 OID 0)
-- Dependencies: 233
-- Name: indirimler_indirim_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.indirimler_indirim_id_seq', 4, true);


--
-- TOC entry 5177 (class 0 OID 0)
-- Dependencies: 245
-- Name: islem_loglari_log_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.islem_loglari_log_id_seq', 43, true);


--
-- TOC entry 5178 (class 0 OID 0)
-- Dependencies: 255
-- Name: istasyonlar_istasyon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.istasyonlar_istasyon_id_seq', 1, false);


--
-- TOC entry 5179 (class 0 OID 0)
-- Dependencies: 231
-- Name: kampanyalar_kampanya_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kampanyalar_kampanya_id_seq', 4, true);


--
-- TOC entry 5180 (class 0 OID 0)
-- Dependencies: 217
-- Name: kullanıcılar_kullanici_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."kullanıcılar_kullanici_id_seq"', 17, true);


--
-- TOC entry 5181 (class 0 OID 0)
-- Dependencies: 235
-- Name: odemeler_odeme_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.odemeler_odeme_id_seq', 33, true);


--
-- TOC entry 5182 (class 0 OID 0)
-- Dependencies: 251
-- Name: otobusler_otobus_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.otobusler_otobus_id_seq', 4, true);


--
-- TOC entry 5183 (class 0 OID 0)
-- Dependencies: 253
-- Name: personel_personel_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.personel_personel_id_seq', 4, true);


--
-- TOC entry 5184 (class 0 OID 0)
-- Dependencies: 229
-- Name: rezervasyonlar_rezervasyon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.rezervasyonlar_rezervasyon_id_seq', 29, true);


--
-- TOC entry 5185 (class 0 OID 0)
-- Dependencies: 241
-- Name: sefer_durumlari_sefer_durumu_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sefer_durumlari_sefer_durumu_id_seq', 580, true);


--
-- TOC entry 5186 (class 0 OID 0)
-- Dependencies: 225
-- Name: seferler_sefer_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.seferler_sefer_id_seq', 701, true);


--
-- TOC entry 5187 (class 0 OID 0)
-- Dependencies: 223
-- Name: sehirler_sehir_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sehirler_sehir_id_seq', 1, false);


--
-- TOC entry 5188 (class 0 OID 0)
-- Dependencies: 239
-- Name: sikayetler_sikayet_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.sikayetler_sikayet_id_seq', 6, true);


--
-- TOC entry 5189 (class 0 OID 0)
-- Dependencies: 249
-- Name: trenler_tren_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.trenler_tren_id_seq', 4, true);


--
-- TOC entry 5190 (class 0 OID 0)
-- Dependencies: 247
-- Name: ucaklar_ucak_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ucaklar_ucak_id_seq', 4, true);


--
-- TOC entry 4900 (class 2606 OID 16494)
-- Name: araclar araclar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.araclar
    ADD CONSTRAINT araclar_pkey PRIMARY KEY (arac_id);


--
-- TOC entry 4916 (class 2606 OID 16615)
-- Name: bagajlar bagajlar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bagajlar
    ADD CONSTRAINT bagajlar_pkey PRIMARY KEY (bagaj_id);


--
-- TOC entry 4906 (class 2606 OID 16540)
-- Name: biletler biletler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT biletler_pkey PRIMARY KEY (bilet_id);


--
-- TOC entry 4898 (class 2606 OID 16487)
-- Name: firmalar firmalar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.firmalar
    ADD CONSTRAINT firmalar_pkey PRIMARY KEY (firma_id);


--
-- TOC entry 4922 (class 2606 OID 16689)
-- Name: hizmetler hizmetler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hizmetler
    ADD CONSTRAINT hizmetler_pkey PRIMARY KEY (hizmet_id);


--
-- TOC entry 4912 (class 2606 OID 16586)
-- Name: indirimler indirimler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.indirimler
    ADD CONSTRAINT indirimler_pkey PRIMARY KEY (indirim_id);


--
-- TOC entry 4924 (class 2606 OID 16701)
-- Name: islem_loglari islem_loglari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islem_loglari
    ADD CONSTRAINT islem_loglari_pkey PRIMARY KEY (log_id);


--
-- TOC entry 4934 (class 2606 OID 16786)
-- Name: istasyonlar istasyonlar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.istasyonlar
    ADD CONSTRAINT istasyonlar_pkey PRIMARY KEY (istasyon_id);


--
-- TOC entry 4910 (class 2606 OID 16574)
-- Name: kampanyalar kampanyalar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kampanyalar
    ADD CONSTRAINT kampanyalar_pkey PRIMARY KEY (kampanya_id);


--
-- TOC entry 4894 (class 2606 OID 16480)
-- Name: kullanicilar kullanıcılar_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kullanicilar
    ADD CONSTRAINT "kullanıcılar_email_key" UNIQUE (email);


--
-- TOC entry 4896 (class 2606 OID 16478)
-- Name: kullanicilar kullanıcılar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kullanicilar
    ADD CONSTRAINT "kullanıcılar_pkey" PRIMARY KEY (kullanici_id);


--
-- TOC entry 4914 (class 2606 OID 16603)
-- Name: odemeler odemeler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odemeler
    ADD CONSTRAINT odemeler_pkey PRIMARY KEY (odeme_id);


--
-- TOC entry 4930 (class 2606 OID 16736)
-- Name: otobusler otobusler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.otobusler
    ADD CONSTRAINT otobusler_pkey PRIMARY KEY (otobus_id);


--
-- TOC entry 4932 (class 2606 OID 16756)
-- Name: personel personel_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel
    ADD CONSTRAINT personel_pkey PRIMARY KEY (personel_id);


--
-- TOC entry 4908 (class 2606 OID 16557)
-- Name: rezervasyonlar rezervasyonlar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar
    ADD CONSTRAINT rezervasyonlar_pkey PRIMARY KEY (rezervasyon_id);


--
-- TOC entry 4920 (class 2606 OID 16648)
-- Name: sefer_durumlari sefer_durumlari_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sefer_durumlari
    ADD CONSTRAINT sefer_durumlari_pkey PRIMARY KEY (sefer_durumu_id);


--
-- TOC entry 4904 (class 2606 OID 16513)
-- Name: seferler seferler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seferler
    ADD CONSTRAINT seferler_pkey PRIMARY KEY (sefer_id);


--
-- TOC entry 4902 (class 2606 OID 16506)
-- Name: sehirler sehirler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sehirler
    ADD CONSTRAINT sehirler_pkey PRIMARY KEY (sehir_id);


--
-- TOC entry 4918 (class 2606 OID 16634)
-- Name: sikayetler sikayetler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sikayetler
    ADD CONSTRAINT sikayetler_pkey PRIMARY KEY (sikayet_id);


--
-- TOC entry 4928 (class 2606 OID 16726)
-- Name: trenler trenler_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.trenler
    ADD CONSTRAINT trenler_pkey PRIMARY KEY (tren_id);


--
-- TOC entry 4926 (class 2606 OID 16717)
-- Name: ucaklar ucaklar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ucaklar
    ADD CONSTRAINT ucaklar_pkey PRIMARY KEY (ucak_id);


--
-- TOC entry 4958 (class 2620 OID 16940)
-- Name: biletler biletlogtrigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER biletlogtrigger AFTER INSERT ON public.biletler FOR EACH ROW EXECUTE FUNCTION public.yenibiletlog();


--
-- TOC entry 4959 (class 2620 OID 16803)
-- Name: kampanyalar kampanyabitistrigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER kampanyabitistrigger AFTER DELETE ON public.kampanyalar FOR EACH ROW EXECUTE FUNCTION public.kampanyasonuindirimguncelle();


--
-- TOC entry 4957 (class 2620 OID 16962)
-- Name: seferler sefer_eklenince_durum_olustur; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER sefer_eklenince_durum_olustur AFTER INSERT ON public.seferler FOR EACH ROW EXECUTE FUNCTION public.sefer_durumu_ekle();


--
-- TOC entry 4960 (class 2620 OID 16968)
-- Name: sikayetler sikayetlogtrigger; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER sikayetlogtrigger AFTER INSERT ON public.sikayetler FOR EACH ROW EXECUTE FUNCTION public.yenisikayetlog();


--
-- TOC entry 4935 (class 2606 OID 16495)
-- Name: araclar araclar_firma_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.araclar
    ADD CONSTRAINT araclar_firma_id_fkey FOREIGN KEY (firma_id) REFERENCES public.firmalar(firma_id);


--
-- TOC entry 4948 (class 2606 OID 16616)
-- Name: bagajlar bagajlar_bilet_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bagajlar
    ADD CONSTRAINT bagajlar_bilet_id_fkey FOREIGN KEY (bilet_id) REFERENCES public.biletler(bilet_id);


--
-- TOC entry 4949 (class 2606 OID 16621)
-- Name: bagajlar bagajlar_firma_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bagajlar
    ADD CONSTRAINT bagajlar_firma_id_fkey FOREIGN KEY (firma_id) REFERENCES public.firmalar(firma_id);


--
-- TOC entry 4940 (class 2606 OID 16541)
-- Name: biletler biletler_kullanici_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT biletler_kullanici_id_fkey FOREIGN KEY (kullanici_id) REFERENCES public.kullanicilar(kullanici_id);


--
-- TOC entry 4941 (class 2606 OID 16546)
-- Name: biletler biletler_sefer_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.biletler
    ADD CONSTRAINT biletler_sefer_id_fkey FOREIGN KEY (sefer_id) REFERENCES public.seferler(sefer_id);


--
-- TOC entry 4952 (class 2606 OID 16690)
-- Name: hizmetler hizmetler_firma_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.hizmetler
    ADD CONSTRAINT hizmetler_firma_id_fkey FOREIGN KEY (firma_id) REFERENCES public.firmalar(firma_id);


--
-- TOC entry 4945 (class 2606 OID 16592)
-- Name: indirimler indirimler_kampanya_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.indirimler
    ADD CONSTRAINT indirimler_kampanya_id_fkey FOREIGN KEY (kampanya_id) REFERENCES public.kampanyalar(kampanya_id);


--
-- TOC entry 4946 (class 2606 OID 16587)
-- Name: indirimler indirimler_kullanici_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.indirimler
    ADD CONSTRAINT indirimler_kullanici_id_fkey FOREIGN KEY (kullanici_id) REFERENCES public.kullanicilar(kullanici_id);


--
-- TOC entry 4953 (class 2606 OID 16702)
-- Name: islem_loglari islem_loglari_kullanici_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.islem_loglari
    ADD CONSTRAINT islem_loglari_kullanici_id_fkey FOREIGN KEY (kullanici_id) REFERENCES public.kullanicilar(kullanici_id);


--
-- TOC entry 4956 (class 2606 OID 16787)
-- Name: istasyonlar istasyonlar_sehir_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.istasyonlar
    ADD CONSTRAINT istasyonlar_sehir_id_fkey FOREIGN KEY (sehir_id) REFERENCES public.sehirler(sehir_id);


--
-- TOC entry 4944 (class 2606 OID 16575)
-- Name: kampanyalar kampanyalar_firma_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kampanyalar
    ADD CONSTRAINT kampanyalar_firma_id_fkey FOREIGN KEY (firma_id) REFERENCES public.firmalar(firma_id);


--
-- TOC entry 4947 (class 2606 OID 16604)
-- Name: odemeler odemeler_bilet_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.odemeler
    ADD CONSTRAINT odemeler_bilet_id_fkey FOREIGN KEY (bilet_id) REFERENCES public.biletler(bilet_id);


--
-- TOC entry 4954 (class 2606 OID 16757)
-- Name: personel personel_arac_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel
    ADD CONSTRAINT personel_arac_id_fkey FOREIGN KEY (arac_id) REFERENCES public.araclar(arac_id);


--
-- TOC entry 4955 (class 2606 OID 16762)
-- Name: personel personel_firma_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.personel
    ADD CONSTRAINT personel_firma_id_fkey FOREIGN KEY (firma_id) REFERENCES public.firmalar(firma_id);


--
-- TOC entry 4942 (class 2606 OID 16558)
-- Name: rezervasyonlar rezervasyonlar_kullanici_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar
    ADD CONSTRAINT rezervasyonlar_kullanici_id_fkey FOREIGN KEY (kullanici_id) REFERENCES public.kullanicilar(kullanici_id);


--
-- TOC entry 4943 (class 2606 OID 16563)
-- Name: rezervasyonlar rezervasyonlar_sefer_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rezervasyonlar
    ADD CONSTRAINT rezervasyonlar_sefer_id_fkey FOREIGN KEY (sefer_id) REFERENCES public.seferler(sefer_id);


--
-- TOC entry 4951 (class 2606 OID 16649)
-- Name: sefer_durumlari sefer_durumlari_sefer_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sefer_durumlari
    ADD CONSTRAINT sefer_durumlari_sefer_id_fkey FOREIGN KEY (sefer_id) REFERENCES public.seferler(sefer_id);


--
-- TOC entry 4936 (class 2606 OID 16514)
-- Name: seferler seferler_arac_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seferler
    ADD CONSTRAINT seferler_arac_id_fkey FOREIGN KEY (arac_id) REFERENCES public.araclar(arac_id);


--
-- TOC entry 4937 (class 2606 OID 16529)
-- Name: seferler seferler_firma_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seferler
    ADD CONSTRAINT seferler_firma_id_fkey FOREIGN KEY (firma_id) REFERENCES public.firmalar(firma_id);


--
-- TOC entry 4938 (class 2606 OID 16519)
-- Name: seferler seferler_kalkis_sehir_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seferler
    ADD CONSTRAINT seferler_kalkis_sehir_id_fkey FOREIGN KEY (kalkis_sehir_id) REFERENCES public.sehirler(sehir_id);


--
-- TOC entry 4939 (class 2606 OID 16524)
-- Name: seferler seferler_varis_sehir_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.seferler
    ADD CONSTRAINT seferler_varis_sehir_id_fkey FOREIGN KEY (varis_sehir_id) REFERENCES public.sehirler(sehir_id);


--
-- TOC entry 4950 (class 2606 OID 16635)
-- Name: sikayetler sikayetler_kullanici_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.sikayetler
    ADD CONSTRAINT sikayetler_kullanici_id_fkey FOREIGN KEY (kullanici_id) REFERENCES public.kullanicilar(kullanici_id);


-- Completed on 2025-03-02 06:26:25

--
-- PostgreSQL database dump complete
--

