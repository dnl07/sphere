import { useEffect, useRef } from "react";

type Props = {
    width?: number;
    height?: number;
    rotating?: boolean;
    lineWidth?: number;
    speed?: number;
};

const Sphere = ({ width = 300, height = 300, rotating = true, lineWidth = 1.2, speed = 0.01 }: Props) => {
    const canvasRef = useRef<HTMLCanvasElement | null>(null);
    const angleRef = useRef(0);
    const rafRef = useRef<number>(0);

    const N = 15;
    const COLOR = "#000000";
    const TILT = 0.35;

    useEffect(() => {
        const canvas = canvasRef.current;
        if (!canvas) return;
        const ctx = canvas.getContext("2d");
        if (!ctx) return;

        const dpr = window.devicePixelRatio || 1;
        canvas.width = width * dpr;
        canvas.height = height * dpr;
        ctx.scale(dpr, dpr);

        const W = width;
        const H = height;
        const CX = W / 2;
        const CY = H / 2;
        const radius = Math.min(W, H) / 2 * 0.9;

        const rotateX = (x: number, y: number, z: number, a: number) => ({
            x,
            y: y * Math.cos(a) - z * Math.sin(a),
            z: y * Math.sin(a) + z * Math.cos(a),
        });

        const project = (x: number, y: number, z: number) => {
            const fov = 600;
            const scale = fov / (fov + z);
            return { x: CX + x * scale, y: CY - y * scale };
        };

        const draw = () => {
            ctx.clearRect(0, 0, W, H);
            ctx.strokeStyle = COLOR;
            ctx.lineWidth = lineWidth;
            ctx.globalAlpha = 0.75;

            const angle = angleRef.current;

            for (let i = 0; i <= N; i++) {
                const lat = (i / N) * Math.PI;
                ctx.beginPath();
                for (let j = 0; j <= 64; j++) {
                    const lon = (j / 64) * 2 * Math.PI + angle;
                    const x = radius * Math.sin(lat) * Math.cos(lon);
                    const y = radius * Math.cos(lat);
                    const z = radius * Math.sin(lat) * Math.sin(lon);
                    const r = rotateX(x, y, z, TILT);
                    const p = project(r.x, r.y, r.z);
                    j === 0 ? ctx.moveTo(p.x, p.y) : ctx.lineTo(p.x, p.y);
                }
                ctx.stroke();
            }

            for (let j = 0; j < N; j++) {
                const lon = (j / N) * 2 * Math.PI + angle;
                ctx.beginPath();
                for (let i = 0; i <= 64; i++) {
                    const lat = (i / 64) * Math.PI;
                    const x = radius * Math.sin(lat) * Math.cos(lon);
                    const y = radius * Math.cos(lat);
                    const z = radius * Math.sin(lat) * Math.sin(lon);
                    const r = rotateX(x, y, z, TILT);
                    const p = project(r.x, r.y, r.z);
                    i === 0 ? ctx.moveTo(p.x, p.y) : ctx.lineTo(p.x, p.y);
                }
                ctx.stroke();
            }

            ctx.globalAlpha = 1;
        };

        const loop = () => {
            if (rotating) {
                angleRef.current += speed;
            }

            draw();
            rafRef.current = requestAnimationFrame(loop);
        };

        rafRef.current = requestAnimationFrame(loop);

        return () => cancelAnimationFrame(rafRef.current);

    }, [width, height, lineWidth, speed]);

    return (
        <div>
            <canvas 
                ref={canvasRef} 
                width={width} 
                height={height} 
                style={{width: width, height: height}}
            />
        </div>
    );
};

export default Sphere;