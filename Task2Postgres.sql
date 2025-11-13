SELECT
    COALESCE(d."DistrictName", 'Total') AS "District",
    COALESCE(h."HospitalName", 'Subtotal') AS "Hospital",
    SUM(CASE WHEN EXTRACT(YEAR FROM dn."DonationDate") = 2023 THEN dn."DonationAmount" ELSE 0 END) AS "2023",
    SUM(CASE WHEN EXTRACT(YEAR FROM dn."DonationDate") = 2024 THEN dn."DonationAmount" ELSE 0 END) AS "2024",
    SUM(CASE WHEN EXTRACT(YEAR FROM dn."DonationDate") = 2025 THEN dn."DonationAmount" ELSE 0 END) AS "2025",
    SUM(dn."DonationAmount") AS "Total"
FROM public."Donations" dn
JOIN public."Hospitals" h ON dn."HospitalId" = h."HospitalId"
JOIN public."Districts" d ON dn."DistrictId" = d."DistrictId"
GROUP BY ROLLUP(d."DistrictName", h."HospitalName")
ORDER BY d."DistrictName" NULLS LAST, h."HospitalName" NULLS LAST;
